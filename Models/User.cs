using MongoDB.Bson.Serialization.Attributes;

namespace WeatherReport.Models
{
    public class User
    {
        [BsonId]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

    }
}
