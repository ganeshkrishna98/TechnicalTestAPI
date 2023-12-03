using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UniversityOfNottinghamAPI.Constants;
using UniversityOfNottinghamAPI.Models.ServiceModels;
using UniversityOfNottinghamAPI.Services.Authentication;

namespace UniversityOfNottinghamAPI.Controllers.Authentication
{
    [Route("api/authentication")]
    [EnableCors]
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
                return Ok(Constant.LoginSuccessful);
            }
            else
            {
                return BadRequest(Constant.InvalidCredentials);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthenticationLoginInput model)
        {
            var username = model.userEmail;
            var password = model.password;

            if (await _authService.CreateUser(username, password))
            {
                return Ok(Constant.SuccessfulUserCreation);
            }
            else
            {
                return BadRequest(Constant.UsernameAlreadyExists);
            }
        }
    }
}