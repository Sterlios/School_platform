using Microsoft.AspNetCore.Mvc;
using School_Platform.Server.DTO;
using School_Platform.Server.Models;
using School_Platform.Server.Services;

namespace School_Platform.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        private readonly CoursesService _coursesService;

        public CoursesController(CoursesService coursesService) =>
            _coursesService = coursesService;

        [HttpGet]
        public List<Course> GetAll() =>
            _coursesService.GetAll();

        [HttpGet]
        [Route("{id}")]
        public Course GetById(int id) =>
            _coursesService.Get(id);

        [HttpPut]
        public void Create(CourseDTO course)
        {
            _coursesService.Create(course);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _coursesService.Delete(id);
        }
    }
}
