using project.Services; // For MongoDBService
using project.Views;    // For MenuView
using System;

class Program
{
    static void Main(string[] args)
    {
        // Initialize MongoDB service with the connection string
        string databaseName = "hotelmanagement";
        string connectionString = "mongodb://localhost:27017";
        MongoDBService mongoService = new MongoDBService(databaseName, connectionString);

        // Initialize the MenuView (which will manage the user interface)
        MenuView menuView = new MenuView(mongoService);

        // Call the method that starts the menu loop
        menuView.ShowMenu();
    }
}
