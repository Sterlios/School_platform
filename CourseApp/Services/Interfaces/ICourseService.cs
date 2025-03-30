
namespace CourseApp.Services.Interfaces
{
    public interface ICourseService
    {
        Task CreateCourse(CourseDTO course);
        Task<bool> DeleteCourse(int id);
        Task GetAllCourses();
        Task GetCourse(int id);
        Task UpdateCourse(CourseDTO course);
    }
}
