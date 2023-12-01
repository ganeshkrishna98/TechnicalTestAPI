using Microsoft.AspNetCore.Mvc;
using UniversityOfNottinghamAPI.Models.ServiceModels;
using UniversityOfNottinghamAPI.Services.Authentication;

namespace UniversityOfNottinghamAPI.Controllers.Authentication
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticationLoginInput model)
        {
            var username = model.userEmail;
            var password = model.password;

            if (await _authService.AuthenticateUser(username, password))
            {
                return Ok(new { Success = true, Message = "Login successful" });
            }
            else
            {
                return BadRequest(new { Success = false, Message = "Invalid username or password" });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthenticationLoginInput model)
        {
            var username = model.userEmail;
            var password = model.password;

            if (await _authService.CreateUser(username, password))
            {
                return Ok(new { Success = true, Message = "User registration successful" });
            }
            else
            {
                return BadRequest(new { Success = false, Message = "Username already exists" });
            }
        }
    }
}