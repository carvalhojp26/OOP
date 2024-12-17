using ManagementSystemLibrary;
using ModelsLibrary;

namespace project.Controllers
{
    public class ClientController : IController<Client>
    {
        private readonly ManagementSystem _managementSystem;

        public ClientController(ManagementSystem managementSystem)
        {
            _managementSystem = managementSystem;
        }

        public int Add(Client client)
        {
            return _managementSystem.AddUser(client);
        }   

        public int Remove(string id)
        {
            return _managementSystem.RemoveUser(id);
        }

        public void DisplayAll()
        {
            var clients = _managementSystem.GetUsers().OfType<Client>();
            foreach (var client in clients)
            {
                Console.WriteLine($"Client: {client.Name}, Email: {client.Email}");
            }
        }
    }
}