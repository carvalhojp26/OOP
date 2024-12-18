using project.Services;
using System;
using ModelsLibrary;
using project.Views;

namespace project.Controllers
{
    public class CreateAccountController
    {
        private MongoDBService _mongoDBService;
        private MenuView _menuView;

        public CreateAccountController(MongoDBService mongoDBService, MenuView menuView)
        {
            _mongoDBService = mongoDBService;
            _menuView = menuView;
        }

        public void CreateAccount(string name, string email, string password)
        {
            var user = new Client(name, email, password);
            int response = _mongoDBService.AddUser(user);

            if (response == 0) {
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