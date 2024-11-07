namespace project.models
{
    public class Booking
    {
        private int id
        private Client client
        private Stay stay
        private DateTime checkIn
        private DateTime checkout

        public int Id
        {
            get => id;
            set => id = value;
        }

        public Client Client
        {
            get => client;
            set => client = value;
        }

        public Stay Stay
        {
            get => stay;
            set => stay = value;
        }

        public DateTime CheckIn
        {
            get => checkIn;
            set => checkIn = value;
        }

        public DateTime Checkout
        {
            get => checkOut;
            set => checkOut = value;
        }

        public Booking (int id, Client client, Stay stay, DateTime checkIn, DateTime checkOut)
        {
            this.id = id;
            this.client = client;
            this.stay = stay;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
        }
    }
}