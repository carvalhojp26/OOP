using System;
using ModelsLibrary;
using project.Services;
using project.Views;

namespace project.Controllers
{
    public class BookingController
    {
        private MongoDBService _mongoDBService;

        public BookingController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        public void ListBookings(string userId)
        {
            var bookings = _mongoDBService.GetBookingsByUserId(userId);
            Console.Clear();
            Console.WriteLine("Your Bookings:");
            if (bookings.Count == 0)
            {
                Console.WriteLine("No bookings found for your account.");
            }
            else
            {
                foreach (var booking in bookings)
                {
                    Console.WriteLine(
                        booking.Stay + " " + booking.ArrivalDate + " - " + booking.LeaveDate
                    );
                }
            }
        }

        public void CreateBooking(string guestId)
        {
            Console.Clear();
            Console.WriteLine("Available Stays:");

            var availableStays = _mongoDBService.GetStays();
            for (int index = 0; index < availableStays.Count; index++)
            {
                Console.WriteLine($"{index + 1}. {availableStays[index]}");
            }

            Console.Write("Select a stay by entering its number: ");
            if (
                !int.TryParse(Console.ReadLine(), out int selectedStayIndex)
                || selectedStayIndex < 1
                || selectedStayIndex > availableStays.Count
            )
            {
                Console.WriteLine("Invalid selection. Returning to the menu...");
                return;
            }

            var selectedStay = availableStays[selectedStayIndex - 1];

            Console.Write("Enter arrival date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime arrivalDate))
            {
                Console.WriteLine("Invalid date format. Returning to the menu...");
                return;
            }

            Console.Write("Enter leave date (yyyy-MM-dd): ");
            if (
                !DateTime.TryParse(Console.ReadLine(), out DateTime leaveDate)
                || leaveDate <= arrivalDate
            )
            {
                Console.WriteLine("Invalid leave date. Returning to the menu...");
                return;
            }

            if (_mongoDBService.HasOverlappingBooking(selectedStay.Id, arrivalDate, leaveDate))
            {
                Console.WriteLine(
                    "The selected stay is already booked for the specified dates. Please choose different dates or a different stay."
                );
                return;
            }

            TimeSpan bookingDuration = leaveDate - arrivalDate;
            int totalBookingCost = bookingDuration.Days * selectedStay.PricePerNight;

            Console.WriteLine($"The total cost for your stay is ${totalBookingCost}.");
            Console.Write("Do you want to confirm this booking? (yes/no): ");
            string userConfirmation = Console.ReadLine()?.ToLower();

            if (userConfirmation != "yes")
            {
                Console.WriteLine("Booking canceled. Returning to the menu...");
                return;
            }

            var newBooking = new Booking(
                guestId,
                selectedStay.Id,
                selectedStay.Name,
                arrivalDate,
                leaveDate
            );

            _mongoDBService.GetCollection<Booking>("bookings").InsertOne(newBooking);
            Console.WriteLine("Your booking has been successfully created!");
        }

        public void DeleteBooking(string userId)
        {
            Console.Clear();
            Console.WriteLine("Your Bookings:");

            var userBookings = _mongoDBService.GetBookingsByUserId(userId);

            if (userBookings.Count == 0)
            {
                Console.WriteLine("You have no bookings to delete.");
                return;
            }

            for (int index = 0; index < userBookings.Count; index++)
            {
                var booking = userBookings[index];
                Console.WriteLine(
                    $"{index + 1}. Stay: {booking.Stay}, Dates: {booking.ArrivalDate:yyyy-MM-dd} - {booking.LeaveDate:yyyy-MM-dd}"
                );
            }

            Console.Write("Enter the number of the booking you want to delete: ");
            if (
                !int.TryParse(Console.ReadLine(), out int selectedIndex)
                || selectedIndex < 1
                || selectedIndex > userBookings.Count
            )
            {
                Console.WriteLine("Invalid selection. Returning to the menu...");
                Console.ReadKey();
                return;
            }

            var selectedBooking = userBookings[selectedIndex - 1];

            Console.Write($"Are you sure you want to delete this booking? (yes/no): ");
            string confirmation = Console.ReadLine()?.ToLower();

            if (confirmation != "yes")
            {
                return;
            }

            bool success = _mongoDBService.DeleteBooking(selectedBooking.Id);
            if (success)
            {
                Console.WriteLine("Booking deleted successfully!");
            }
            else
            {
                Console.WriteLine("Failed to delete booking. Please try again.");
            }
        }
    }
}
