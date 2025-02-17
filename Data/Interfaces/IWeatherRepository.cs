using WeatherReport.Models;

namespace WeatherReport.Data.Interfaces
{
    public interface IWeatherRepository
    {
        Task<IEnumerable<Weather>> GetAllAsync();
        Task<Weather> GetByIdAsync(int weatherId);
        Task CreateAsync(Weather weather);
        Task UpdateAsync(Weather weather);
        Task DeleteAsync(int weatherId);
    }
}
