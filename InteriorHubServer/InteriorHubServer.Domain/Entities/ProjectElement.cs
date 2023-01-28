namespace InteriorHubServer.Domain.Entities
{
    public class ProjectElement
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public ProjectImage? ProjectImage { get; set; }
        public long? ProjectImageId { get; set; }
        public string? Text { get; set; }
        public Project Project { get; set; }
        public long ProjectId { get; set; }
        public int OrderNumber { get; set; }
    }
}
