using System;
using project.Controllers;
using project.Services;

namespace project.Views
{
    public class AdminMenuView
    {
        private readonly StayController _stayController;
        private readonly UserController _userController;

        public AdminMenuView(StayController stayController, UserController userController)
        {
            _stayController = stayController;
            _userController = userController;
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
                Console.WriteLine("4. Logout    ");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _userController.ListUsers();
                        break;

                    case "2":
                        _stayController.ListStays();
                        break;

                    case "3":
                        _stayController.AddStay();
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
