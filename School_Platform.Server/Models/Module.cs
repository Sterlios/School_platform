namespace School_Platform.Server.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }

        public Course Course { get; set; } = null;
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}