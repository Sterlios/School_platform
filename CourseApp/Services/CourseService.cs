namespace CourseApp.Services
{
    public class CourseService
    {
        private ApplicationDbContext _context;

        public CourseService(ApplicationDbContext context) =>
            _context = context;
    }
}
