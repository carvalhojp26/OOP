using System;
using ModelsLibrary;
using project.Services;

namespace project.Controllers
{
    public class UserController : IUserController
    {
        private readonly MongoDBService _mongoDBService;

        public UserController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        public void ListUsers()
        {
            Console.Clear();
            Console.WriteLine("Users List:");

            var users = _mongoDBService.GetUsers();

            if (users.Count == 0)
            {
                Console.WriteLine("No users found.");
            }
            else
            {
                foreach (var user in users)
                {
                    Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Role: {user.Role}");
                }
            }
        }
    }
}
