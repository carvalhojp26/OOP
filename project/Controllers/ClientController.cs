using ManagementSystemLibrary;
using ModelsLibrary;

namespace project.Controllers
{
    public class ClientController
    {
        private readonly ManagementSystem _managementSystem;

        public ClientController(ManagementSystem managementSystem)
        {
            _managementSystem = managementSystem;
        }

        public int AddClient(Client client)
        {
            return _managementSystem.AddPerson(client);
        }   

        public int RemoveClient(int id)
        {
            return _managementSystem.RemovePerson(id);
        }

        public void ShowAllClients()
        {
            var clients = _managementSystem.GetPeople().OfType<Client>();
            foreach (var client in clients)
            {
                Console.WriteLine($"Client: {client.Name}, Email: {client.Email}");
            }
        }
    }
}