using ModelsLibrary;
using System;
using System.Collections.Generic;

namespace ManagementSystemLibrary
{
    public class ManagementSystem
    {
        private List<Person> people = new List<Person>();
        private List<Stay> stays = new List<Stay>();
        private List<Booking> bookings = new List<Booking>();

        public int AddPerson(Person person)
        {
            if (person == null || people.Exists(p => p.Id == person.Id))
            {
                return 0;
            }

            people.Add(person);
            return 1;
        }

        public int RemovePerson(int id)
        {
            var personToRemove = people.Find(person => person.Id == id);

            if (personToRemove == null)
            {
                return 0;
            }

            people.Remove(personToRemove);
            return 1;
        }

        public List<Person> GetPeople()
        {
            return new List<Person>(people);
        }

        public Person GetPersonById(int id)
        {
            return people.Find(person => person.Id == id);
        }

        public List<T> GetPeopleByType<T>() where T : Person
        {
            return new List<T>(people.OfType<T>());
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