using CourseApp.Services.Interfaces;

namespace CourseApp.Services
{
    internal class CourseService : ICourseService
    {
        private ICourseRepository _repository;

        public CourseService(ICourseRepository repository) =>
            _repository = repository;
    }
}
