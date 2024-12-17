using MongoDB.Bson.Serialization.Attributes;

namespace ModelsLibrary
{
    [BsonDiscriminator("Client")]
    public class Client : User
    {
        public Client(string name, string email, string password) : base(name, email, password, "Client") {}

        public override void DisplayRole()
        {
            Console.WriteLine($"Role: Client");
        }
    }
}
