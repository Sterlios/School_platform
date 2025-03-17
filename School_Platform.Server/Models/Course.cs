namespace School_Platform.Server.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Module> Modules { get; set; } = new List<Module>();
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
