using project.models;
using System;
using System.Collections.Generic;

namespace ManagementSystemLibrary
{
    public class ManagementSystem
    {
        private List<Client> clients = new List<Client>();
        private List<Stay> stays = new List<Stay>();
        private List<Booking> bookings = new List<Booking>();

        public int AddClient(Client client)
        {
            if (client == null || clients.Exists(c => c.id == client.Id))
            {
                return 0;
            }

            clients.Add(client);
            return 1;
        }

        public int RemoveClient(int id)
        {
            if (id <= 0)
            {
                return 0;
            }

            var clientToRemove = clients.Find(client => client.Id == id);

            if (clientToRemove == null)
            {
                return 0;
            }

            clients.Remove(clientToRemove);
            return 1;
        }

        public List<Client> GetClients()
        {
            return new List<Client>(clients); // return a copy of the list to avoid modifying the original list
        }

        public Client GetClientById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return clients.Find(client => client.Id == id);
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
            if (id <= 0)
            {
                return 0;
            }

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
            if (id <= 0)
            {
                return null;
            }

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
            if (id <= 0)
            {
                return 0;
            }

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