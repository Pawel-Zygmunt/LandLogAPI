using LandLogAPI.Dtos;
using LandLogAPI.Services;

using Microsoft.AspNetCore.Mvc;

namespace LandLogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserDto dto)
        {
            await _authService.Register(dto);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginUser([FromBody] LoginUserDto dto)
        {
            var token = await _authService.GenerateJwt(dto);

            Response.Cookies.Append("X-Access-Token", token, new CookieOptions() { HttpOnly = true, Secure = true, SameSite = SameSiteMode.None });

            return Ok();
        }
    }
}
