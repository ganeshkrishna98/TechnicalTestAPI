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
            var userEmail = model.userEmail;
            var password = model.password;

            AuthenticationOutput result = await _authService.AuthenticateUser(userEmail, password);
            if (result.loginStatus==Constant.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthenticationLoginInput model)
        {
            var userEmail = model.userEmail;
            var password = model.password;

            if (await _authService.CreateUser(userEmail, password))
            {
                return Ok(Constant.SuccessfulUserCreation);
            }
            else
            {
                return BadRequest(Constant.userEmailAlreadyExists);
            }
        }
    }
}