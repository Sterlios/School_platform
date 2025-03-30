namespace CourseApp.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
