namespace School_Platform.Server.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Module> Modules { get; set; }
        public List<Student> Students { get; set; }
    }
}
