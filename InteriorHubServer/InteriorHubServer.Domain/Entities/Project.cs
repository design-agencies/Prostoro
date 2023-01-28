namespace InteriorHubServer.Domain.Entities
{
    public class Project
    {
        public long Id { get; set; }
        public string? Name { get; set; } = default;
        public Image? MainImage { get; set; }
        public ICollection<ProjectImage>? Images { get; set; }
        public ICollection<ProjectElement>? Elements { get; set; }
        public ICollection<Like>? Likes { get; set; }
        public ICollection<Save>? Saves { get; set; }
        public long AgencyId { get; set; }
        public virtual Agency? Agency { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDraft { get; set; }

        public Project()
        {
            Elements = new List<ProjectElement>();
            Images = new List<ProjectImage>();
            Likes = new List<Like>();
            Saves = new List<Save>();
        }
    }
}
