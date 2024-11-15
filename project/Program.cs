using ModelsLibrary;
using ManagementSystemLibrary;
using System;   

public class Program
{
    // Just an example of how to use the ManagementSystem class
    public static void Main(string[] args)
    {
        ManagementSystem system = new ManagementSystem();

        system.AddPerson(new Client(1, "John Doe", "john@example.com", "123456789"));
        system.AddPerson(new Admin(2, "Alice Admin", "alice@admin.com", "Manager"));
        system.AddPerson(new Client(3, "Jane Smith", "jane@example.com", "987654321"));

        Console.WriteLine("All People:");
        foreach (var person in system.GetPeople())
        {
            Console.WriteLine(person);
        }

        Console.WriteLine("\nClients:");
        foreach (var client in system.GetPeopleByType<Client>())
        {
            Console.WriteLine(client);
        }

        Console.WriteLine("\nAdmins:");
        foreach (var admin in system.GetPeopleByType<Admin>())
        {
            Console.WriteLine(admin);
        }

        system.RemovePerson(1);
        Console.WriteLine("\nAfter Removing John Doe:");
        foreach (var person in system.GetPeople())
        {
            Console.WriteLine(person);
        }
    }
}
