using WeatherReport.Models;

namespace WeatherReport.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);   
    }
}
