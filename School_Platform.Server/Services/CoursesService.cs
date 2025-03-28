using Microsoft.EntityFrameworkCore;
using School_Platform.Server.DTO;
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

        internal IEnumerable<SmallCourseInfoDTO> GetAll() =>
            _context.Courses.Select(c => new SmallCourseInfoDTO()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            });

        internal CourseStructureDTO? Get(int id) =>
            _context.Courses
            .Where(c => c.Id == id)
            .Include(c => c.Modules)
            .Select(c => new CourseStructureDTO
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Modules = c.Modules.Select(m => new SmallModuleInfoDTO
                {
                    Id = m.Id,
                    Name = m.Name,
                    Description = m.Description
                }).ToList()
            })
            .FirstOrDefault();

        public void CreateCourse(CreatedCourseDTO courseDto)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(courseDto.Name);

            if (courseDto.Modules is null || courseDto.Modules.Count == 0)
                throw new ArgumentException("Course must has modules.");

            foreach (var module in courseDto.Modules)
            {
                ArgumentNullException.ThrowIfNullOrWhiteSpace(module.Name);

                if (module.Lessons is null || module.Lessons.Count == 0)
                    throw new ArgumentException("Module must has lessons.");

                foreach (var lesson in module.Lessons)
                {
                    ArgumentNullException.ThrowIfNullOrWhiteSpace(lesson.Name);
                }
            }

            string query =
                "INSERT INTO \"Courses\" (\"Name\",\"Description\")" +
                $"\n\tVALUES ('{courseDto.Name}', '{courseDto.Description}');";

            if (courseDto.Modules.Any())
            {
                foreach (CreatedModuleDTO moduleDto in courseDto.Modules)
                {
                    query +=
                        "\nINSERT INTO \"Modules\" (\"Name\",\"Description\",\"CourseId\")" +
                        $"\n\tSELECT '{moduleDto.Name}', '{moduleDto.Description}', \"Id\" " +
                        "\n\tFROM \"Courses\"" +
                        $"\n\tWHERE \"Name\" = '{courseDto.Name}';";

                    if (moduleDto.Lessons.Any())
                    {
                        foreach (var lessonDto in moduleDto.Lessons)
                        {
                            query +=
                                "\nINSERT INTO \"Lessons\" (\"Name\",\"Description\",\"ModuleId\")" +
                                $"\n\tSELECT '{lessonDto.Name}', '{lessonDto.Description}', \"Modules\".\"Id\" " +
                                "\n\tFROM \"Modules\"" +
                                "\n\tINNER JOIN \"Courses\" on \"Courses\".\"Id\" = \"Modules\".\"CourseId\"" +
                                $"\n\tWHERE \"Modules\".\"Name\" = '{moduleDto.Name}' AND \"Courses\".\"Name\" = '{courseDto.Name}';";
                        }
                    }
                }
            }

            _context.Database.ExecuteSqlRaw(query);
        }

        internal void DeleteCourse(int id)
        {
            _context.Courses.Where(c => c.Id == id)
            .Include(c => c.Modules)
                .ThenInclude(m => m.Lessons)
            .ExecuteDelete();
        }

        internal void CreateModule(CreatedModuleDTO moduleDto)
        {
            Module module = new Module()
            {
                Name = moduleDto.Name,
                Description = moduleDto.Description,
                Course = _context.Courses.Where(c => c.Id == moduleDto.CourseId).FirstOrDefault()
            };

            _context.Modules.Add(module);

            if (moduleDto.Lessons.Any())
            {
                foreach (var lessonDto in moduleDto.Lessons)
                {
                    lessonDto.ModuleId = module.Id;
                    CreateLesson(lessonDto);
                }
            }
        }

        public void CreateLesson(LessonDTO lessonDto)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(lessonDto.Name);

            var module = _context.Modules.Where(m => m.Id == lessonDto.ModuleId).FirstOrDefault()
                ?? throw new InvalidOperationException("Module is not found.");

            Lesson lesson = new Lesson()
            {
                Name = lessonDto.Name,
                Description = lessonDto.Description,
                Module = module
            };

            _context.Lessons.Add(lesson);

            _context.SaveChanges();
        }
    }
}
