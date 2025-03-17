namespace School_Platform.Server.DTO
{
    public class CourseStructureDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SmallModuleInfoDTO> Modules { get; set; } = new List<SmallModuleInfoDTO>();
    }
}
