using Microsoft.AspNetCore.Mvc;

namespace TechnicalTestAPI.Controllers.DatabaseManagement
{
    public class DatabaseManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
