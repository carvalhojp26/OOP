using ModelsLibrary;
using ManagementSystemLibrary;
using System;   

public class Program
{
    public static void Main(string[] args)
    {
        ManagementSystem system = new ManagementSystem();

        // Adicionar diferentes tipos de pessoas
        system.AddPerson(new Client(1, "John Doe", "john@example.com", "123456789"));
        system.AddPerson(new Admin(2, "Alice Admin", "alice@admin.com", "Manager"));
        system.AddPerson(new Client(3, "Jane Smith", "jane@example.com", "987654321"));

        // Listar todas as pessoas
        Console.WriteLine("All People:");
        foreach (var person in system.GetPeople())
        {
            Console.WriteLine(person);
        }

        // Listar somente clientes
        Console.WriteLine("\nClients:");
        foreach (var client in system.GetPeopleByType<Client>())
        {
            Console.WriteLine(client);
        }

        // Listar somente administradores
        Console.WriteLine("\nAdmins:");
        foreach (var admin in system.GetPeopleByType<Admin>())
        {
            Console.WriteLine(admin);
        }

        // Remover uma pessoa
        system.RemovePerson(1); // Remove John Doe
        Console.WriteLine("\nAfter Removing John Doe:");
        foreach (var person in system.GetPeople())
        {
            Console.WriteLine(person);
        }
    }
}
