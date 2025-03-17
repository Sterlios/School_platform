namespace School_Platform.Server.DTO
{
    public class CourseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ModuleDTO> Modules { get; set; } = new List<ModuleDTO>();
        public List<StudentDTO> Students { get; set; } = new List<StudentDTO>();
    }
}
