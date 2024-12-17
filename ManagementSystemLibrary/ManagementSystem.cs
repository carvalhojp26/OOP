using ModelsLibrary;
using System;
using System.Collections.Generic;

namespace ManagementSystemLibrary
{
    public class ManagementSystem
    {
        private List<User> users = new List<User>();
        private List<Stay> stays = new List<Stay>();
        private List<Booking> bookings = new List<Booking>();

        public int AddUser(User user)
        {
            if (user == null || users.Exists(u => u.Id == user.Id))
            {
                return 0;
            }

            users.Add(user);
            return 1;
        }

        public int RemoveUser(string id)
        {
            var userToRemove = users.Find(user => user.Id == id);

            if (userToRemove == null)
            {
                return 0;
            }

            users.Remove(userToRemove);
            return 1;
        }

        public List<User> GetUsers()
        {
            return new List<User>(users);
        }

        public User GetUserById(string id)
        {
            return users.Find(user => user.Id == id);
        }

        public List<T> GetUsersByType<T>() where T : User
        {
            return new List<T>(users.OfType<T>());
        }

        public int AddStay(Stay stay)
        {
            if (stay == null || stays.Exists(s => s.Id == stay.Id))
            {
                return 0;
            }

            stays.Add(stay);
            return 1;
        }

        public int RemoveStay(int id)
        {
            var stayToRemove = stays.Find(stay => stay.Id == id);

            if (stayToRemove == null)
            {
                return 0;
            }

            stays.Remove(stayToRemove);
            return 1;
        }

        public List<Stay> GetStays()
        {
            return new List<Stay>(stays);
        }

        public Stay GetStayById(int id)
        {
            return stays.Find(stay => stay.Id == id);
        }

        public int AddBooking(Booking booking)
        {
            if (booking == null || bookings.Exists(b => b.Id == booking.Id))
            {
                return 0;
            }

            bookings.Add(booking);
            return 1;
        }

        public int RemoveBooking(int id)
        {
            var bookingToRemove = bookings.Find(booking => booking.Id == id);

            if (bookingToRemove == null)
            {
                return 0;
            }

            bookings.Remove(bookingToRemove);
            return 1;
        }

        public List<Booking> GetBookings()
        {
            return new List<Booking>(bookings);
        }

        public Booking GetBookingById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return bookings.Find(booking => booking.Id == id);
        }
    }
}
