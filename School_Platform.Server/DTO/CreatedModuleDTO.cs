namespace School_Platform.Server.DTO
{
    public class CreatedModuleDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }

        public List<LessonDTO> Lessons { get; set; } = new List<LessonDTO>();
    }
}