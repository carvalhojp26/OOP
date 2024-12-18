using System;
using project.Controllers;

namespace project.Views
{
    public class LoginView
    {
        private LoginController _loginController;

        public LoginView(LoginController loginController)
        {
            _loginController = loginController;
        }

        public void DisplayLoginView()
        {
            Console.Clear();
            Console.WriteLine("Login");

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            _loginController.HandleLogin(email, password);
        }
    }
}
