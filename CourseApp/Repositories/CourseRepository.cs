using CourseApp.Repositories.Interfaces;

namespace CourseApp.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context) =>
            _context = context;
    }
}
