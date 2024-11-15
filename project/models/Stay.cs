namespace project.models
{
    public class Stay
    {
        private int id;
        private string type; // Flat, House
        private string adress;
        private int capacity; // Number of guests
        private int price; // Price per night
        private bool status; // Available, Unavailable
        
        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Type
        {
            get => type;
            get => type = value;
        }

        public string Adress
        {
            get => adress;
            set => adress = value;
        }

        public int Capacity
        {
            get => capacity;
            set => capacity = value;
        }

        public int Price
        {
            get => prince;
            set => price = value;
        }

        public string Status
        {
            get => status;
            set => status = value;
        }

        public Stay (int id, string type, string adress, int capacity, int price, string status)
        {
            this.id = id;
            this.type = type;
            this.adress = adress;
            this.capacity = capacity;
            this.price = price;
            this.status = status;
        }

        public void ChangeStatus()
        {
            if (status == true)
            {
                status = false;
            }
            else
            {
                status = true;
            }
        }
    }
}