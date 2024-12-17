namespace ModelsLibrary
{
    public class Client : User
    {
        private string phoneNumber;

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (value.Length == 9)
                {
                    phoneNumber = value;
                }

            }
        }

        public Client(int id, string name, string email, string phoneNumber) : base(id, name, email)
        {
            this.phoneNumber = phoneNumber;
        }

        public override void DisplayRole()
        {
            Console.WriteLine("Role: Client");
        }
    }
}