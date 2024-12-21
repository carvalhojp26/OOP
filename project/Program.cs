using System;
using project.Services;
using project.Views;

class Program
{
    static void Main(string[] args)
    {
        string databaseName = "hotelmanagement";
        string connectionString = "mongodb://localhost:27017";
        MongoDBService mongoService = new MongoDBService(databaseName, connectionString);

        MenuView menuView = new MenuView(mongoService);

        menuView.ShowMenu();
    }
}
