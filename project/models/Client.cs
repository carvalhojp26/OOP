namespace project.models
{
    public class Client : Person
    {
        private string phoneNumber;

        public string PhoneNumber
        {
            get => phoneNumber;
            set => phoneNumber = value;
        }

        public Client(int id, string name, string email, string phoneNumber) : base(id, name, email)
        {
            this.phoneNumber = phoneNumber;
        }
    }
}