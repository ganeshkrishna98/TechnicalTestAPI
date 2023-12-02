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
        public async Task<IActionResult> ReadUser()
        {
            var result = await _userManagementService.ReadUser();
            return Ok(result);
        }

        [HttpPost]
        [Route("create-users")]
        public async Task<IActionResult> CreateUser(UserManagementInput userManagementInput)
        {
            var result = await _userManagementService.CreateUser(userManagementInput);
            return Ok(result);
        }

        [HttpPost]
        [Route("update-users")]
        public async Task<IActionResult> UpdateUser(UserManagementInput userManagementInput)
        {
            var result = await _userManagementService.UpdateUser(userManagementInput);
            return Ok(result);
        }

        [HttpPost]
        [Route("delete-users")]
        public async Task<IActionResult> DeleteUser(UserManagementInput userManagementInput)
        {
            var result = await _userManagementService.DeleteUser(userManagementInput);
            return Ok(result);
        }
    }
}