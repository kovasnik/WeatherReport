using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherReport.BLL.Interfaces;

namespace WeatherReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }

        [HttpPost("signUp")]
        public async Task<IActionResult> SignUp()
        {
            return Ok();
        }
    }
}
