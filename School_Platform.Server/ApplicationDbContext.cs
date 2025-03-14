using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School_Platform.Server.Models;

namespace School_Platform.Server
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>().ToTable("Courses");
            builder.Entity<Module>().ToTable("Modules");
            builder.Entity<Student>().ToTable("Students");
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Lesson>().ToTable("Lessons");

            base.OnModelCreating(builder);
        }
    }
}
