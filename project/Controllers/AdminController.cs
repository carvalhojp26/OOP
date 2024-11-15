using ManagementSystemLibrary;
using ModelsLibrary;

namespace project.Controllers
{
    public class AdminController : IController<Admin>
    {
        private readonly ManagementSystem _managementSystem;

        public AdminController(ManagementSystem managementSystem)
        {
            _managementSystem = managementSystem;
        }

        public int Add(Admin admin)
        {
            return _managementSystem.AddPerson(admin);
        }

        public int Remove(int id)
        {
            return _managementSystem.RemovePerson(id);
        }

        public void DisplayAll()
        {
            var admins = _managementSystem.GetPeople().OfType<Admin>();
            foreach (var admin in admins)
            {
                Console.WriteLine($"Admin: {admin.Name}, Email: {admin.Email}");
            }
        }
    }
}