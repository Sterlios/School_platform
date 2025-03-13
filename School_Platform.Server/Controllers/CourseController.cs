using Microsoft.AspNetCore.Mvc;

namespace School_Platform.Server.Controllers
{
    [Controller]
    [Route("courses")]
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult Get() =>
            Json(_context.Courses.ToList());
    }
}
