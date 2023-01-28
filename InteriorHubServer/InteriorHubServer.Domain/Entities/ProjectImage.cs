namespace InteriorHubServer.Domain.Entities
{
    public class ProjectImage
    {
        public long Id { get; set; }
        public Image? Image { get; set; }
        public Project? Project { get; set; }
        public ICollection<Tag>? Tags { get; set; }
        public bool InInspiration { get; set; }
        public ProjectElement? ProjectElement { get; set; }
        public long? ProjectElementId { get; set; }

        public ProjectImage()
        {
            Tags = new List<Tag>();
        }
    }
}
