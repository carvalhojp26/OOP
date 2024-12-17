using System;
using project.Services;

namespace project.Views
{
    public class LoginView
    {
        private MongoDBService _mongoService;
        private MenuView _menuView;

        public LoginView(MongoDBService mongoService, MenuView menuView)
        {
            _mongoService = mongoService;
            _menuView = menuView;
        }

        public void Login()
        {
            Console.Clear();
            Console.WriteLine("Login");

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            bool success = _mongoService.Login(email, password);

            if (success)
            {
                Console.WriteLine("Login successful!");
            }
            else
            {
                Console.WriteLine("Invalid login credentials.");
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
                _menuView.ShowMenu();
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
