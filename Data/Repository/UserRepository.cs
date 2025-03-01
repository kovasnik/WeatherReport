using MongoDB.Driver;
using WeatherReport.Data.Interfaces;
using WeatherReport.Models;

namespace WeatherReport.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly IMongoCollection<User> _userCollection;

        public UserRepository(WeatherReportDbContext context)
        {
            _userCollection = context.Users;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userCollection.Find(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userCollection.Find(_ => true).ToListAsync();
        }

        public async Task AddUser(User user)
        {
            await _userCollection.InsertOneAsync(user);
        }

        public async Task DeleteUser(int id)
        {
            await _userCollection.DeleteOneAsync(u => u.Id == id);
        }

        public async Task UpdateUser(User user)
        {
            await _userCollection.ReplaceOneAsync(u => u.Id == user.Id, user);
        }
    }
}
