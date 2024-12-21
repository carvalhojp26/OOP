using project.Services;
using project.Views;

namespace project.Controllers
{
    public class LoginController : ILoginController
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
            var loginView = new LoginView(this);
            loginView.DisplayLoginView();
        }

        public void HandleLogin(string email, string password)
        {
            bool success = _mongoDBService.Login(email, password);

            if (success)
            {
                Console.WriteLine("Login successful!");

                var user = _mongoDBService.FindUser(email);

                if (user != null)
                {
                    if (user.Role == "Admin")
                    {
                        var stayController = new StayController(_mongoDBService);
                        var userController = new UserController(_mongoDBService); // Create UserController
                        var adminMenuView = new AdminMenuView(stayController, userController); // Pass both controllers
                        adminMenuView.DisplayAdminMenuView();
                    }
                    else if (user.Role == "Client")
                    {
                        var clientMenuView = new ClientMenuView(
                            new BookingController(_mongoDBService),
                            user.Id
                        );
                        clientMenuView.DisplayClientMenuView();
                    }
                    else
                    {
                        Console.WriteLine("Unknown role. Redirecting to the main menu...");
                        _menuView.ShowMenu();
                    }
                }
                else
                {
                    Console.WriteLine("User not found after successful login. Returning to menu.");
                    _menuView.ShowMenu();
                }
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
