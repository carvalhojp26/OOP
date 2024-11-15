namespace project.models
{
    public class Person
    {
        private int id;
        private string name;
        private string email;

        public int Id
        {
            get => id;
            set
            {
                if (value <= 0)
                {
                    return 0;
                }

                id = value;
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return 0;
                }

                name = value;
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if (!value.Contains("@"))
                {
                    return 0;
                }

                email = value;
            }
        }

        public Person(int id, string name, string email)
        {
            this.id = id;
            this.name = name;
            this.email = email;
        }
    }
}