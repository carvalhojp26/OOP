namespace ModelsLibrary
{
    public abstract class Person : IPerson
    {
        private int id;
        private string name;
        private string email;

        public int Id
        {
            get => id;
            set
            {
                if (value > 0)
                {
                    id = value;
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

        public Person(int id, string name, string email)
        {
            this.id = id;
            this.name = name;
            this.email = email;
        }

        // abstract method
        public abstract void DisplayRole();

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Email: {Email}";
        }
    }
}