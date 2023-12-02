using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UniversityOfNottinghamAPI.Database;
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
        [Route("create-user")]
        public async Task<IActionResult> CreateUser(UserManagementInput userManagementInput)
        {
            var result = await _userManagementService.CreateUser(userManagementInput);
            return result;
        }
    }
}
