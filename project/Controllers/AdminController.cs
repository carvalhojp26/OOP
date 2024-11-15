using ManagementSystemLibrary;
using ModelsLibrary;

namespace project.Controllers
{
    public class AdminController
    {
        private readonly ManagementSystem _managementSystem;

        public AdminController(ManagementSystem managementSystem)
        {
            _managementSystem = managementSystem;
        }

        public int AddAdmin(Admin admin)
        {
            return _managementSystem.AddPerson(admin);
        }

        public int RemoveAdmin(int id)
        {
            return _managementSystem.RemovePerson(id);
        }

        public void ShowAllAdmins()
        {
            var admins = _managementSystem.GetPeople().OfType<Admin>();
            foreach (var admin in admins)
            {
                Console.WriteLine($"Admin: {admin.Name}, Email: {admin.Email}");
            }
        }
    }
}