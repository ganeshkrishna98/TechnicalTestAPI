using Microsoft.AspNetCore.Mvc;

namespace UniversityOfNottinghamAPI.Controllers.Document
{
    public class DocumentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
