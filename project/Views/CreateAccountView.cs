using System;
using project.Controllers;

namespace project.Views
{
    public class CreateAccountView
    {
        private CreateAccountController _createAccountController;

        public CreateAccountView(CreateAccountController createAccountController)
        {
            _createAccountController = createAccountController;
        }

        public void DisplayCreateAccountView()
        {
            Console.Clear();
            Console.WriteLine("Create New Account");

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            _createAccountController.CreateAccount(name, email, password);
        }
    }
}