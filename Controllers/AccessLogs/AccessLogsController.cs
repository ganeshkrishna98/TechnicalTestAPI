using Microsoft.AspNetCore.Mvc;

namespace UniversityOfNottinghamAPI.Controllers.AccessLogs
{
    public class AccessLogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
