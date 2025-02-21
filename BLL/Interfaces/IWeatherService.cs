using WeatherReport.Dto;

namespace WeatherReport.BLL.Interfaces
{
    public interface IWeatherService
    {
        Task<CoordinatesDto> GetLocationAsync(string city);
        Task<string> GetCurrentWeatherAsync(double ltn, double lon);
        Task<string> GetWeeklyForecastAsync(double ltn, double lon);
        Task AddWeatherAsync(WeatherDto weatherDto);
        Task DeleteWeatherAsync(int weatherId);
    }
}
