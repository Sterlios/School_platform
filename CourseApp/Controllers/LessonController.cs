using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class LessonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
