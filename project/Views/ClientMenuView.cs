using System;
using project.Controllers;
using project.Services;

namespace project.Views
{
    public class ClientMenuView
    {
        private BookingController _bookingController;
        private string _loggedInUserId;

        public ClientMenuView(BookingController bookingController, string userId)
        {
            _bookingController = bookingController;
            _loggedInUserId = userId;
        }

        public void DisplayClientMenuView()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Client Menu:");
                Console.WriteLine("1. My bookings");
                Console.WriteLine("2. Make a booking");
                Console.WriteLine("3. Cancel a booking");
                Console.WriteLine("4. Logout");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _bookingController.ListBookings(_loggedInUserId);
                        break;

                    case "2":
                        _bookingController.CreateBooking(_loggedInUserId);
                        break;

                    case "3":
                        _bookingController.DeleteBooking(_loggedInUserId);
                        break;

                    case "4":
                        Console.WriteLine("Logging out...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
