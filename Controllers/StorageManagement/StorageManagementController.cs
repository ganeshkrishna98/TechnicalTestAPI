using Microsoft.AspNetCore.Mvc;

namespace UniversityOfNottinghamAPI.Controllers.StorageManagement
{
    public class StorageManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
