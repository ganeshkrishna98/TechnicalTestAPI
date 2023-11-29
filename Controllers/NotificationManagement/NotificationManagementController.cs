using Microsoft.AspNetCore.Mvc;

namespace UniversityOfNottinghamAPI.Controllers.NotificationManagement
{
    public class NotificationManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
