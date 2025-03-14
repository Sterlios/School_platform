using Microsoft.AspNetCore.Mvc;
using School_Platform.Server.Models;
using School_Platform.Server.Services;

namespace School_Platform.Server.Controllers
{
    [Controller]
    [Route("courses")]
    public class CourseController : Controller
    {
        private readonly CoursesService _coursesService;

        public CourseController(CoursesService coursesService)
        {
            _coursesService = coursesService;
        }

        [HttpGet]
        public JsonResult Get() =>
            Json(_coursesService.GetAll());

        [HttpGet]
        [Route("course")]
        public Course GetById(int id) =>
            _coursesService.Get(id);
    }
}
