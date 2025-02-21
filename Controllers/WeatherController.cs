using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherReport.BLL.Interfaces;
using WeatherReport.Dto;

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

        [HttpGet("city")]
        public async Task<IActionResult> GetCurrentWeather(string city)
        {
            var location = await _weatherService.GetLocationAsync(city);
            var currentWeather = await _weatherService.GetCurrentWeatherAsync(location.Ltn, location.Lon);
            return Ok(currentWeather);
        }

        [HttpGet("forecast/city")]
        public async Task<IActionResult> GetForecastForWeek(string city)
        {
            var location = await _weatherService.GetLocationAsync(city);
            var forecast = await _weatherService.GetWeeklyForecastAsync(location.Ltn, location.Lon);
            return Ok(forecast);
        }

        [HttpPost]
        public async Task<IActionResult> AddWeatherAsync(WeatherDto weatherDto)
        {
            await _weatherService.AddWeatherAsync(weatherDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWeather(int weatherId)
        {
            await _weatherService.DeleteWeatherAsync(weatherId);
            return Ok();
        }


    }
}
