using System.Text.Json.Serialization;

namespace WeatherReport.Dto
{
    public class CoordinatesDto
    {
        [JsonPropertyName("lat")]
        public double Ltn { get; set; }
        [JsonPropertyName("lon")]
        public double Lon { get; set; }
    }
}
