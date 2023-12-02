using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UniversityOfNottinghamAPI.Models.ServiceModels;
using UniversityOfNottinghamAPI.Services.UserManagement;

namespace UniversityOfNottinghamAPI.Controllers.UserManagement
{
    [Route("api/user-management")]
    [EnableCors]
    public class UserManagementController : Controller
    {
        private readonly IUserManagementService _userManagementService;

        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        [HttpPost]
        [Route("read-users")]
        public async Task<IActionResult> ReadUsers()
        {
            var result = await _userManagementService.ReadUsers();
            return Ok(result);
        }

        [HttpPost]
        [Route("create-users")]
        public async Task<IActionResult> CreateUsers(UserAccounts userManagementInput)
        {
            var result = await _userManagementService.CreateUsers(userManagementInput);
            return Ok(result);
        }

        [HttpPost]
        [Route("update-users")]
        public async Task<IActionResult> UpdateUsers(UserAccounts userManagementInput)
        {
            var result = await _userManagementService.UpdateUsers(userManagementInput);
            return Ok(result);
        }

        [HttpPost]
        [Route("delete-users")]
        public async Task<IActionResult> DeleteUsers(UserAccounts userManagementInput)
        {
            var result = await _userManagementService.DeleteUsers(userManagementInput);
            return Ok(result);
        }
    }
}