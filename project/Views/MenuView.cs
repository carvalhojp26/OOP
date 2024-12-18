using System;
using project.Services;
using project.Controllers;

namespace project.Views
{
    public class MenuView
    {
        private MongoDBService _mongoDBService;
        private readonly LoginController _loginController;
        private readonly CreateAccountController _createAccountController;

        public MenuView(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
            _loginController = new LoginController(mongoDBService, this);
            _createAccountController = new CreateAccountController(mongoDBService, this);
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
                    var createAccountView = new CreateAccountView(_createAccountController);
                    createAccountView.DisplayCreateAccountView();
                    break;

                case "2":
                    _loginController.Login();
                    break;

                case "3":
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}