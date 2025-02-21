using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherReport.BLL.Interfaces;

namespace WeatherReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {

        private readonly IWeatherService _weatherService;
        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentWeather(string city)
        {
            var location = await _weatherService.GetLocation(city);
            var currentWeather = await _weatherService.GetCurrentWeather(location.Ltn, location.Lon);
            return Ok(currentWeather);
        }
    }
}
