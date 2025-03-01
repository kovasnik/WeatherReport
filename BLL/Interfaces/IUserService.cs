using WeatherReport.Dto;

namespace WeatherReport.BLL.Interfaces
{
    public interface IUserService
    {
        Task<LoginDto> GetUserByIdAsync(int id);
        Task DeleteUserAsync(int id);
        Task UpdateUserAsync(LoginDto userDto);
        Task AddUserAsync(LoginDto userDto);
    }
}
