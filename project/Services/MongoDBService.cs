using ModelsLibrary;
using MongoDB.Driver;

namespace project.Services
{
    public class MongoDBService
    {
        private readonly IMongoDatabase _database;

        public MongoDBService(string databaseName, string connectionString)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoDatabase GetDatabase()
        {
            return _database;
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }

        public int AddUser(User user)
        {
            var existingUser = GetCollection<User>("users")
                .Find(u => u.Email == user.Email)
                .FirstOrDefault();

            if (existingUser != null)
            {
                return 0;
            }

            GetCollection<User>("users").InsertOne(user);
            return 1;
        }

        public bool Login(string email, string password)
        {
            var userCollection = GetCollection<User>("users");
            var user = userCollection.Find(u => u.Email == email).FirstOrDefault();

            if (user == null)
            {
                return false;
            }

            if (user.Password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User FindUser(string email)
        {
            return GetCollection<User>("users").Find(u => u.Email == email).FirstOrDefault();
        }

        public List<Stay> GetStays()
        {
            var collection = _database.GetCollection<Stay>("stays");
            return collection.Find(_ => true).ToList();
        }

        public List<Booking> GetBookingsByUserId(string userId)
        {
            var collection = _database.GetCollection<Booking>("bookings");
            return collection.Find(booking => booking.UserId == userId).ToList();
        }

        public bool HasOverlappingBooking(string stayId, DateTime arrivalDate, DateTime leaveDate)
        {
            var bookingCollection = GetCollection<Booking>("bookings");

            var conflictingBookings = bookingCollection
                .Find(existingBooking =>
                    existingBooking.StayId == stayId
                    && (
                        (
                            arrivalDate >= existingBooking.ArrivalDate
                            && arrivalDate < existingBooking.LeaveDate
                        )
                        || (
                            leaveDate > existingBooking.ArrivalDate
                            && leaveDate <= existingBooking.LeaveDate
                        )
                        || (
                            arrivalDate <= existingBooking.ArrivalDate
                            && leaveDate >= existingBooking.LeaveDate
                        )
                    )
                )
                .ToList();

            return conflictingBookings.Count > 0;
        }

        public bool DeleteBooking(string bookingId)
        {
            var result = GetCollection<Booking>("bookings")
                .DeleteOne(booking => booking.Id == bookingId);
            return result.DeletedCount > 0;
        }

        public bool AddStay(Stay newStay)
        {
            var existingStay = GetCollection<Stay>("stays")
                .Find(s => s.Id == newStay.Id)
                .FirstOrDefault();

            if (existingStay != null)
            {
                return false;
            }

            GetCollection<Stay>("stays").InsertOne(newStay);
            return true;
        }

        public List<User> GetUsers()
        {
            var collection = _database.GetCollection<User>("users");
            return collection.Find(_ => true).ToList();
        }
    }
}
