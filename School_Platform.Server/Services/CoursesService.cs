
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

        internal List<Course> GetAll() =>
            _context.Courses.ToList();

        internal Course? Get(int id) =>
            _context.Courses
            .Where(c => c.Id == id)
            .Include(c => c.Modules)
            .Select(c => new Course
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Modules = c.Modules.Select(m => new Module
                {
                    Id = m.Id,
                    Name = m.Name,
                    Description = m.Description,
                    CourseId = m.CourseId
                }).ToList()
            })
            .FirstOrDefault();

        public void Create(CourseDTO courseDto)
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
                    Module module = new Module()
                    {
                        Name = moduleDto.Name,
                        Description = moduleDto.Description,
                        Course = course
                    };

                    if (moduleDto.Lessons.Any())
                    {
                        foreach (var lessonDto in moduleDto.Lessons)
                        {
                            Lesson lesson = new Lesson()
                            {
                                Name = lessonDto.Name,
                                Description = lessonDto.Description,
                                Module = module
                            };

                            module.Lessons.Add(lesson);
                        }
                    }

                    course.Modules.Add(module);
                }
            }

            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        internal void Delete(int id)
        {
            Course course = _context.Courses.Where(c => c.Id == id)
            .Include(c => c.Modules)
                .ThenInclude(m => m.Lessons).FirstOrDefault();

            if (course is not null)
            {
                foreach (Module module in course.Modules)
                {
                    foreach (Lesson lesson in module.Lessons)
                        _context.Lessons.Remove(lesson);

                    _context.Modules.Remove(module);
                }

                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }
    }
}
