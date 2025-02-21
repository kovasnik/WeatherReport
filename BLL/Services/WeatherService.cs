using AutoMapper;
using System.Text.Json;
using WeatherReport.BLL.Interfaces;
using WeatherReport.Data.Interfaces;
using WeatherReport.Dto;
using WeatherReport.Models;

namespace WeatherReport.BLL.Services
{
    public class WeatherService : IWeatherService
    {
        private const string GeocodingUrl = "http://api.openweathermap.org/geo/1.0/direct?q={0}&limit=1&appid={1}";
        private const string CurrentWeatherUrl = "https://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid={2}&units=metric";
        private const string ForecastUrl = "https://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&appid={2}&units=metric";

        private readonly IWeatherRepository _weatherRepository;
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public WeatherService(IWeatherRepository weatherRepository, IConfiguration configuration, 
            IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _weatherRepository = weatherRepository;
            _apiKey = configuration["Weather:ApiKey"];
            _httpClient = httpClientFactory.CreateClient();
            _mapper = mapper;
        }

        public async Task<CoordinatesDto> GetLocationAsync(string city)
        {
            var coordinates = await _httpClient.GetStringAsync(string.Format(GeocodingUrl, city, _apiKey));
            var location = JsonSerializer.Deserialize<List<CoordinatesDto>>(coordinates);
            
            return location.First();
        }

        public async Task<string> GetCurrentWeatherAsync(double ltn, double lon)
        {
            var currentWeather = await _httpClient.GetStringAsync(string.Format(CurrentWeatherUrl, ltn, lon, _apiKey));
            return currentWeather;
        }

        public async Task<string> GetWeeklyForecastAsync(double ltn, double lon)
        {
            var forecast = await _httpClient.GetStringAsync(string.Format(ForecastUrl, ltn, lon, _apiKey));

            return forecast;
        }

        public async Task AddWeatherAsync(WeatherDto weatherDto)
        {
            var weather = _mapper.Map<Weather>(weatherDto);
            await _weatherRepository.CreateAsync(weather);
        }

        public async Task DeleteWeatherAsync(int weatherId)
        {
            var weather = _weatherRepository.GetByIdAsync(weatherId);
            if (weather == null) throw new InvalidOperationException("There is no weather like called");

            await _weatherRepository.DeleteAsync(weatherId);
        }
    }
}
