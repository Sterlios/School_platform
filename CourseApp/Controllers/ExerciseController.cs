using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class ExerciseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
