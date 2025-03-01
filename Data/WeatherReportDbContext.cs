using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WeatherReport.Models;

namespace WeatherReport.Data
{
    public class WeatherReportDbContext 
    {
        private readonly IMongoDatabase _database;

        public WeatherReportDbContext(IOptions<WeatherReportDbSettings> weatherReportDbSettings, IMongoClient mongoClient)
        {
            _database = mongoClient.GetDatabase(weatherReportDbSettings.Value.DatabaseName);
        }

        public IMongoCollection<Weather> Weathers => _database.GetCollection<Weather>("Weather");
        public IMongoCollection<User> Users => _database.GetCollection<User>("User");
    }
}
