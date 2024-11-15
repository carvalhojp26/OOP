using project.Controllers;
using ManagementSystemLibrary;
using ModelsLibrary;

class Program
{
    static void Main(string[] args)
    {
        var management = new ManagementSystem();

        var clientController = new ClientController(management);
        var adminController = new AdminController(management);

        clientController.Add(new Client(1, "John Doe", "john@example.com", "123456789"));
        adminController.Add(new Admin(2, "Jane Admin", "jane@example.com", "987654321"));

        clientController.DisplayAll();
        adminController.DisplayAll();

        clientController.Remove(1);
        clientController.DisplayAll();
        adminController.DisplayAll();
    }
}
