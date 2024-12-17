using MongoDB.Driver;
using ModelsLibrary;

namespace project.Services
{
    public class MongoDBService
    {
        private readonly IMongoDatabase _database; // Interface provided by MongoDB.Driver && private fields named with _ prefix

        public MongoDBService(string databaseName, string connectionString)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoDatabase GetDatabase()
        {
            return _database;
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }

        public int AddUser(User user)
        {
            var existingUser = GetCollection<User>("users").Find(u => u.Email == user.Email).FirstOrDefault();

            if (existingUser != null)
            {
                return 0;
            }

            GetCollection<User>("users").InsertOne(user);
            return 1;
        }

        public bool Login(string email, string password)
        {
            var userCollection = GetCollection<User>("users");
            var user = userCollection.Find(u => u.Email == email).FirstOrDefault();

            if (user == null)
            {
                return false;
            }

            if (user.Password == password)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }
    }
}