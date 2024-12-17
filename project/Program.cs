using System;
using System.Linq; // Required for ToList()
using project.Services;
using MongoDB.Driver;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string databaseName = "hotelmanagement";
            string connectionString = "mongodb://localhost:27017";

            MongoDBService mongoService = new MongoDBService(databaseName, connectionString);

            var collections = mongoService.GetDatabase().ListCollectionNames().ToList();

            if (collections.Any())
            {
                Console.WriteLine("Connected to MongoDB! Collections found:");
                foreach (var collection in collections)
                {
                    Console.WriteLine($" - {collection}");
                }
            }
            else
            {
                Console.WriteLine("Connected to MongoDB, but no collections were found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to connect to MongoDB: {ex.Message}");
        }
    }
}
