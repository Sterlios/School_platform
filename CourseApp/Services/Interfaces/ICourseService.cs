
using CourseApp.DTO;

namespace CourseApp.Services.Interfaces
{
    public interface ICourseService
    {
        Task<CourseDTO> CreateCourse(CourseDTO course);
        Task<bool> DeleteCourse(int id);
        Task<IEnumerable<CourseDTO>> GetAllCourses();
        Task<CourseDTO> GetCourse(int id);
        Task<CourseDTO> UpdateCourse(CourseDTO course);
    }
}
