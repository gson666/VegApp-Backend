using Backend_almog.DTO;
using Backend_almog.Services.AuthSer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Backend_almog.Controllers
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
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            var result = await _authService.RegisterAsync(registerDTO);
            if (result == null) return BadRequest("Registration Failed.");

            return Ok(new { token = result, user = registerDTO.UserName });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var result = await _authService.LoginAsync(loginDTO);
            if (result == null) return Unauthorized();

            return Ok(new { token = result, user = loginDTO.UserName });
        }
        [Authorize]
        [HttpGet("profile/{userName}")]
        public async Task<IActionResult> GetUserProfile(string userName)
        {
            var userProfile = await _authService.GetUserProfile(userName);
            if (userProfile == null)
            {
                return NotFound("User not found");
            }

            return Ok(userProfile);
        }
    }
}
