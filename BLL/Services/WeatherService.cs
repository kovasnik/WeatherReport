using WeatherReport.BLL.Interfaces;
using WeatherReport.Data.Interfaces;

namespace WeatherReport.BLL.Services
{
    public class WeatherService : IWeatherService
    {
        private const string GeocodingUrl = "http://api.openweathermap.org/geo/1.0/direct?q={0}&limit=1&appid={1}";
        private const string CurrentWeatherUrl = "https://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid={2}";

        private readonly IWeatherRepository _weatherRepository;

        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }


    }
}
