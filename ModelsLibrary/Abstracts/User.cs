using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ModelsLibrary
{
    [BsonKnownTypes(typeof(Admin), typeof(Client))]
    public abstract class User : IUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private string id;

        private string name;
        private string email;
        private string password;
        private string role;

        public string Id
        {
            get => id;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    id = value;
                }
                else
                {
                    throw new ArgumentException("ID must be valid.");
                }
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if (value.Contains("@"))
                {
                    email = value;
                }
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    password = value;
                }
            }
        }

        public string Role
        {
            get => role;
            private set => role = value;
        }

        public User() { }

        public User(string name, string email, string password, string role)
        {
            this.id = string.Empty;
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.email = email ?? throw new ArgumentNullException(nameof(email));
            this.password = password ?? throw new ArgumentNullException(nameof(password));
            this.role = role ?? throw new ArgumentNullException(nameof(role));
        }

        public abstract void DisplayRole();

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Email: {Email}, Role: {Role}";
        }
    }
}
