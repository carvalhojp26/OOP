using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ModelsLibrary
{
    public class Booking
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private string id;

        private string userId;
        private string stayId;
        private string stay;
        private DateTime arrivalDate;
        private DateTime leaveDate;

        public string Id
        {
            get => id;
            set => id = value;
        }

        public string UserId
        {
            get => userId;
            set => userId = value;
        }

        public string StayId
        {
            get => stayId;
            set => stayId = value;
        }

        public string Stay
        {
            get => stay;
            set => stay = value;
        }

        public DateTime ArrivalDate
        {
            get => arrivalDate;
            set => arrivalDate = value;
        }

        public DateTime LeaveDate
        {
            get => leaveDate;
            set => leaveDate = value;
        }

        // Constructor
        public Booking(
            string userId,
            string stayId,
            string stay,
            DateTime arrivalDate,
            DateTime leaveDate
        )
        {
            id = ObjectId.GenerateNewId().ToString(); // Automatically generate ID
            this.userId = userId;
            this.stayId = stayId;
            this.stay = stay;
            this.arrivalDate = arrivalDate;
            this.leaveDate = leaveDate;
        }

        public int CalculateTotalNights()
        {
            TimeSpan duration = leaveDate - arrivalDate;
            return duration.Days;
        }

        public override string ToString()
        {
            return $"Booking ID: {id}, Stay: {stay}, Arrival: {arrivalDate.ToShortDateString()}, Leave: {leaveDate.ToShortDateString()}";
        }
    }
}
