using Microsoft.AspNetCore.Mvc;

namespace UniversityOfNottinghamAPI.Controllers.DatabaseManagement
{
    public class DatabaseManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
