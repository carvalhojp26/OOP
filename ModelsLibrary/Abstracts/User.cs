namespace ModelsLibrary
{
    public abstract class User : IUser
    {
        private int id;
        private string name;
        private string email;
        private string hashedPassword;

        public int Id
        {
            get => id;
            set
            {
                if (value > 0)
                {
                    id = value;
                }
                else
                {
                    throw new ArgumentException("ID must be greater than 0");
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
                if (value.Contains("@")) // fix this
                {
                    email = value;
                }
            }
        }

        public string HashedPassword
        {
            get => hashedPassword;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    hashedPassword = value;
                }
            }
        }

        public User(int id, string name, string email)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.hashedPassword = hashedPassword;
        }

        // abstract method
        public abstract void DisplayRole();

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Email: {Email}";
        }
    }
}