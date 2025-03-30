using CourseApp.DTO;
using CourseApp.Repositories.Interfaces;
using CourseApp.Services.Interfaces;

namespace CourseApp.Services
{
    internal class CourseService : ICourseService
    {
        private ICourseRepository _repository;

        public CourseService(ICourseRepository repository) =>
            _repository = repository;

        public Task CreateCourse(CourseDTO course) => throw new NotImplementedException();
        public Task<bool> DeleteCourse(int id) => throw new NotImplementedException();
        public Task GetAllCourses() => throw new NotImplementedException();
        public Task GetCourse(int id) => throw new NotImplementedException();
        public Task UpdateCourse(CourseDTO course) => throw new NotImplementedException();
    }
}
