using AutoMapper;
using WeatherReport.Dto;
using WeatherReport.Models;

namespace WeatherReport.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WeatherDto, Weather>();
            CreateMap<Weather, WeatherDto>();
        }
    }
}
