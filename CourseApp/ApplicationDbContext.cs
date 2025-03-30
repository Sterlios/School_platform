using CourseApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseApp
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
    }
}
