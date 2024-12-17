using System;
using project.Services;
using ModelsLibrary;

namespace project.Views
{
    public class CreateAccountView
    {
        private MongoDBService _mongoDBService;
        private MenuView _menuView;

        public CreateAccountView(MongoDBService mongoDBService, MenuView menuView)
        {
            _mongoDBService = mongoDBService;
            _menuView = menuView;
        }

        public void CreateAccount()
        {
            Console.Clear();
            Console.WriteLine("Create New Account");

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            var user = new Client(name, email, password);

            int response = _mongoDBService.AddUser(user);

            if (response == 0)
            {
                Console.WriteLine("Email already registered.");
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
                _menuView.ShowMenu();
                return;
            }

            Console.WriteLine("Account created successfully!");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
            _menuView.ShowMenu();
        }
    }
}