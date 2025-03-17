
using Microsoft.EntityFrameworkCore;
using School_Platform.Server.DTO;
using School_Platform.Server.Models;

namespace School_Platform.Server.Services
{
    public class CoursesService
    {
        private readonly ApplicationDbContext _context;

        public CoursesService(ApplicationDbContext context)
        {
            _context = context;
        }

        internal IEnumerable<SmallCourseInfoDTO> GetAll() =>
            _context.Courses.Select(c => new SmallCourseInfoDTO()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            });

        internal CourseStructureDTO? Get(int id) =>
            _context.Courses
            .Where(c => c.Id == id)
            .Include(c => c.Modules)
            .Select(c => new CourseStructureDTO
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Modules = c.Modules.Select(m => new SmallModuleInfoDTO
                {
                    Id = m.Id,
                    Name = m.Name,
                    Description = m.Description
                }).ToList()
            })
            .FirstOrDefault();

        public void Create(CreatedCourseDTO courseDto)
        {
            Course course = new Course()
            {
                Name = courseDto.Name,
                Description = courseDto.Description
            };

            if (courseDto.Modules.Any())
            {
                foreach (var moduleDto in courseDto.Modules)
                {
                    CreateModule(course, moduleDto);
                }
            }

            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        internal void Delete(int id)
        {
            _context.Courses.Where(c => c.Id == id)
            .Include(c => c.Modules)
                .ThenInclude(m => m.Lessons)
            .ExecuteDelete();
        }

        private void CreateModule(Course toCourse, ModuleDTO moduleDto)
        {
            Module module = new Module()
            {
                Name = moduleDto.Name,
                Description = moduleDto.Description,
                Course = toCourse
            };

            if (moduleDto.Lessons.Any())
            {
                foreach (var lessonDto in moduleDto.Lessons)
                {
                    CreateLesson(module, lessonDto);
                }
            }

            toCourse.Modules.Add(module);
        }

        private void CreateLesson(Module toModule, LessonDTO lessonDto)
        {
            Lesson lesson = new Lesson()
            {
                Name = lessonDto.Name,
                Description = lessonDto.Description,
                Module = toModule
            };

            toModule.Lessons.Add(lesson);
        }
    }
}
