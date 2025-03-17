using Microsoft.AspNetCore.Mvc;
using School_Platform.Server.DTO;
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
        public IEnumerable<SmallCourseInfoDTO> GetAll() =>
            _coursesService.GetAll();

        [HttpGet]
        [Route("{id}")]
        public CourseStructureDTO GetById(int id) =>
            _coursesService.Get(id);

        [HttpPut]
        public void Create(CreatedCourseDTO course)
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
