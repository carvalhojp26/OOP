using MongoDB.Bson.Serialization.Attributes;

namespace ModelsLibrary
{
    [BsonDiscriminator("Admin")]
    public class Admin : User
    {
        public Admin(string name, string email, string password)
            : base(name, email, password, "Admin") { }

        public override void DisplayRole()
        {
            Console.WriteLine($"Role: Admin");
        }
    }
}
