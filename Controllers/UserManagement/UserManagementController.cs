using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UniversityOfNottinghamAPI.Database;
using UniversityOfNottinghamAPI.Services.UserManagement;

namespace UniversityOfNottinghamAPI.Controllers.UserManagement
{
    //[ApiVersion("1.0")]
    [Route("api/user-management")]
    [EnableCors]
    public class UserManagementController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IUserManagementService _userManagementService;

        public UserManagementController(DatabaseContext context, IUserManagementService userManagementService)
        {
            _context = context;
            _userManagementService = userManagementService;
        }

        [HttpPost]
        [Route("create-user")]
        public async Task<IActionResult> CreateUser(string username, string password)
        {
            var result = await _userManagementService.CreateUser(username, password);
            return result;
        }
    }
}
