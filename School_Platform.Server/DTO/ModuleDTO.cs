namespace School_Platform.Server.DTO
{
    public class ModuleDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<LessonDTO> Lessons { get; set; } = new List<LessonDTO>();
    }
}