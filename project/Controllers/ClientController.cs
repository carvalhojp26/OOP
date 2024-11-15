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
            return _managementSystem.AddPerson(client);
        }   

        public int Remove(int id)
        {
            return _managementSystem.RemovePerson(id);
        }

        public void DisplayAll()
        {
            var clients = _managementSystem.GetPeople().OfType<Client>();
            foreach (var client in clients)
            {
                Console.WriteLine($"Client: {client.Name}, Email: {client.Email}");
            }
        }
    }
}