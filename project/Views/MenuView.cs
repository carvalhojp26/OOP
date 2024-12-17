using System;
using project.Services;

namespace project.Views
{
    public class MenuView
    {
        private MongoDBService _mongoDBService;

        public MenuView(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the booking management system!");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter your choice: ");
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    var createAccountView = new CreateAccountView(_mongoDBService, this);
                    createAccountView.CreateAccount();
                    break;

                case "2":
                    var loginView = new LoginView(_mongoDBService, this);
                    loginView.Login();
                    break;

                case "3":
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}