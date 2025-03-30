using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class ModuleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
