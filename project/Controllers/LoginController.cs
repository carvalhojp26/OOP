using project.Services;
using project.Views;

namespace project.Controllers
{
    public class LoginController
    {
        private MongoDBService _mongoDBService;
        private MenuView _menuView;

        public LoginController(MongoDBService mongoDBService, MenuView menuView)
        {
            _mongoDBService = mongoDBService;
            _menuView = menuView;
        }

        public void Login()
        {
            var loginView = new LoginView(this); // understand this
            loginView.DisplayLoginView();
        }

        public void HandleLogin(string email, string password)
        {
            bool success = _mongoDBService.Login(email, password);

            if (success)
            {
                Console.WriteLine("Login successful!");
                // Proceed to the next step after successful login
            }
            else
            {
                Console.WriteLine("Invalid login credentials.");
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
                _menuView.ShowMenu();
            }
        }
    }
}
