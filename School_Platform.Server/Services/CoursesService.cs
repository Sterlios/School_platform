
using Microsoft.EntityFrameworkCore;
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
    }
}
