namespace School_Platform.Server.DTO
{
    public class CreatedCourseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<CreatedModuleDTO> Modules { get; set; }
    }
}
