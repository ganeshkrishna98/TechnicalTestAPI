using Microsoft.AspNetCore.Mvc;

namespace UniversityOfNottinghamAPI.Controllers.DeviceManagement
{
    public class DeviceManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
