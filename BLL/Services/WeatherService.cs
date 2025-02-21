using System.Text.Json;
using WeatherReport.BLL.Interfaces;
using WeatherReport.Data.Interfaces;
using WeatherReport.Dto;

namespace WeatherReport.BLL.Services
{
    public class WeatherService : IWeatherService
    {
        private const string GeocodingUrl = "http://api.openweathermap.org/geo/1.0/direct?q={0}&limit=1&appid={1}";
        private const string CurrentWeatherUrl = "https://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid={2}";

        private readonly IWeatherRepository _weatherRepository;
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public WeatherService(IWeatherRepository weatherRepository, IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _weatherRepository = weatherRepository;
            _apiKey = configuration["Weather:ApiKey"];
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<CoordinatesDto> GetLocation(string city)
        {
            var coordinates = await _httpClient.GetStringAsync(string.Format(GeocodingUrl, city, _apiKey));
            var location = JsonSerializer.Deserialize<List<CoordinatesDto>>(coordinates);
            
            return location.First();
        }

        public async Task<string> GetCurrentWeather(double ltn, double lon)
        {
            var currentWeather = await _httpClient.GetStringAsync(string.Format(CurrentWeatherUrl, ltn, lon, _apiKey));
            return currentWeather;
        }


    }
}
