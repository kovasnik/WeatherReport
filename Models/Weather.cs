using MongoDB.Bson.Serialization.Attributes;

namespace WeatherReport.Models
{
    public class Weather
    {
        [BsonId]
        public int Id { get; set; }
        public string City { get; set; }
        public float Temperature { get; set; }
        public float FeelsLikeTemp { get; set; }
        public int Humidity { get; set; }
        public float WindSpeed { get; set; }
        public float WindTemp { get; set; }
        public float? Rain { get; set; }
        public string WetherDescription { get; set; }
        public DateTime DateTime { get; set; }
    }
}
