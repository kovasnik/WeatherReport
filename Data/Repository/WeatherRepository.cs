using MongoDB.Driver;
using WeatherReport.Data.Interfaces;
using WeatherReport.Models;

namespace WeatherReport.Data.Repository
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly IMongoCollection<Weather> _weatherCollection;
        public WeatherRepository(WeatherReportDbContext context)
        {
            _weatherCollection = context.Weathers;
        }

        public async Task<Weather> GetByIdAsync(int weatherId)
        {
            return await _weatherCollection.Find(w =>  w.Id == weatherId).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Weather>> GetAllAsync()
        {
            return await _weatherCollection.Find(_ => true).ToListAsync();
        }
        public async Task UpdateAsync(Weather weather)
        {
            await _weatherCollection.ReplaceOneAsync(w => w.Id == weather.Id, weather);
        }

        public async Task CreateAsync(Weather weather)
        {
            await _weatherCollection.InsertOneAsync(weather);
        }

        public async Task DeleteAsync(int weatherId)
        {
            await _weatherCollection.DeleteOneAsync(w => w.Id == weatherId);
        }

    }
}
