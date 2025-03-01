using AutoMapper;
using WeatherReport.BLL.Interfaces;
using WeatherReport.Data.Interfaces;
using WeatherReport.Dto;

namespace WeatherReport.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<LoginDto> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddUserAsync(LoginDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(LoginDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
