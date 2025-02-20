using WeatherReport.Dto;

namespace WeatherReport.BLL.Interfaces
{
    public interface IWeatherService
    {
        Task<CoordinatesDto> GetLocation(string city);
        Task<string> GetCurrentWeather(double ltn, double lon);
    }
}
