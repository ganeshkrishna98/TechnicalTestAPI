using Microsoft.AspNetCore.Mvc;

namespace UniversityOfNottinghamAPI.Controllers.UserManagement
{
    public class UserManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
