using MongoDB.Driver;

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
    }
}