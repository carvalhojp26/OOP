using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ModelsLibrary
{
    public class Stay
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private string id;

        private string name;
        private int pricePerNight;
        private int maxOccupancy;

        public string Id
        {
            get => id;
            set => id = value;
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

        public int PricePerNight
        {
            get => pricePerNight;
            set
            {
                if (value >= 0)
                {
                    pricePerNight = value;
                }
            }
        }

        public int MaxOccupancy
        {
            get => maxOccupancy;
            set
            {
                if (value > 0)
                {
                    maxOccupancy = value;
                }
            }
        }

        public Stay(string id, string name, int pricePerNight, int maxOccupancy)
        {
            this.id = id;
            this.name = name;
            this.pricePerNight = pricePerNight;
            this.maxOccupancy = maxOccupancy;
        }

        public override string ToString()
        {
            return $"Stay ID: {Id}, Name: {Name}, Price per Night: {PricePerNight}, Max Occupancy: {MaxOccupancy}";
        }
    }
}
