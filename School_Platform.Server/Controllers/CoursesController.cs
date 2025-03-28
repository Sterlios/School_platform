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
        public void CreateCourse(CreatedCourseDTO course)
        {
            _coursesService.CreateCourse(course);
        }

        [HttpPut]
        [Route("{course.id}")]
        public void CreateModule(CreatedModuleDTO module)
        {
            _coursesService.CreateModule(module);
        }

        [HttpPut]
        [Route("lesson")]
        public void CreateLesson(LessonDTO lesson)
        {
            _coursesService.CreateLesson(lesson);
        }

        [HttpDelete]
        public void DeleteCourse(int id)
        {
            _coursesService.DeleteCourse(id);
        }
    }
}
