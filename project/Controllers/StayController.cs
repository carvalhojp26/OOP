using System;
using ModelsLibrary;
using project.Services;

namespace project.Controllers
{
    public class StayController : IStayController
    {
        private readonly MongoDBService _mongoDBService;

        public StayController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        public void AddStay()
        {
            Console.Clear();
            Console.WriteLine("Add New Stay:");

            Console.Write("Enter Stay Name: ");
            string stayName = Console.ReadLine();

            Console.Write("Enter Price Per Night: ");
            if (!int.TryParse(Console.ReadLine(), out int pricePerNight))
            {
                Console.WriteLine("Invalid price. Returning to menu...");
                return;
            }

            Console.Write("Enter Max Occupancy: ");
            if (!int.TryParse(Console.ReadLine(), out int maxOccupancy))
            {
                Console.WriteLine("Invalid occupancy. Returning to menu...");
                return;
            }

            var newStay = new Stay(stayName, pricePerNight, maxOccupancy);

            if (_mongoDBService.AddStay(newStay))
            {
                Console.WriteLine("Stay added successfully!");
            }
            else
            {
                Console.WriteLine("A stay with this name already exists.");
            }
        }

        public void ListStays()
        {
            Console.Clear();
            var stays = _mongoDBService.GetStays();

            Console.WriteLine("Available Stays:");
            if (stays.Count == 0)
            {
                Console.WriteLine("No stays available.");
            }
            else
            {
                foreach (var stay in stays)
                {
                    Console.WriteLine(
                        $"Name: {stay.Name}, Price Per Night: {stay.PricePerNight}, Max Occupancy: {stay.MaxOccupancy}"
                    );
                }
            }
        }
    }
}
