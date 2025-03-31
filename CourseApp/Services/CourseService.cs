using CourseApp.DTO;
using CourseApp.Repositories.Interfaces;
using CourseApp.Services.Interfaces;

namespace CourseApp.Services
{
    internal class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;

        public CourseService(ICourseRepository repository) =>
            _repository = repository;

        public Task<CourseDTO> CreateCourse(CourseDTO course) => throw new NotImplementedException();
        public Task<bool> DeleteCourse(int id) => throw new NotImplementedException();
        public Task<IEnumerable<CourseDTO>> GetAllCourses() => throw new NotImplementedException();
        public Task<CourseDTO> GetCourse(int id) => throw new NotImplementedException();
        public Task<CourseDTO> UpdateCourse(CourseDTO course) => throw new NotImplementedException();
    }
}
