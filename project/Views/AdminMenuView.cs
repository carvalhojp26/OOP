using System;
using project.Services;

namespace project.Views
{
    public class AdminMenuView
    {
        public AdminMenuView()
        {
            // Constructor logic (if needed) can go here
        }

        public void DisplayAdminMenuView()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Admin Menu:");
                Console.WriteLine("1. Users");
                Console.WriteLine("2. Stays");
                Console.WriteLine("3. Add new stay");
                Console.WriteLine("4. Logout");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Displaying users...");
                        // Call method to display bookings
                        break;

                    case "2":
                        Console.WriteLine("Displaying stays...");
                        // Call method to make a booking
                        break;

                    case "3":
                        Console.WriteLine("Adding new stay...");
                        // Call method to cancel a booking
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
