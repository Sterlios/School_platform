namespace CourseApp.Models
{
    internal class Module
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; }
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
