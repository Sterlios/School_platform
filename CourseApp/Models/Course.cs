namespace CourseApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; }
        public List<Module> Modules { get; set; } = new List<Module>();
    }
}
