namespace School_Platform.Server.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public User User { get; set; }
        public List<Course> Courses { get; set; }
    }
}
