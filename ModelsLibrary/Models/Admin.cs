namespace ModelsLibrary
{
    public class Admin : Person
    {
        private string password;

        public string Password
        {
            get => password;
            set => password = value;
        }

        public Admin(int id, string name, string email, string password) : base(id, name, email)
        {
            this.password = password;
        }

        public override void DisplayRole()
        {
            Console.WriteLine("Role: Admin");
        }
    }
}