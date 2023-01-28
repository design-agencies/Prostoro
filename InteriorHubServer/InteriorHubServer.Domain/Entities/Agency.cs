namespace InteriorHubServer.Domain.Entities
{
    public class Agency
    {
        public long Id { get; set; }
        public User User { get; set; }
        public long? UserId { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }
        public Image LogoImg { get; set; }
        public long? LogoImgId { get; set; }
        public Image HeaderImg { get; set; }
        public long? HeaderImgId { get; set; }
        public string? ContactFirstName { get; set; }
        public string? ContactLastName { get; set; }
        public string? About { get; set; }
        public string? Description { get; set; } // key-words
        public City? City { get; set; }
        public long? CityId { get; set; }
        public string? Budget { get; set; }
        public bool RemoteAvailable { get; set; }
        public bool OnSiteAvailable { get; set; } = true;
        public bool IsVerified { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedOn { get; set; }
        public ICollection<Project>? Projects { get; set; }
        public ICollection<Tag>? Tags { get; set; }
        public ICollection<User>? Followers { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Save>? Saves { get; set; }

        public Agency()
        {
            Projects = new List<Project>();
            Reviews = new List<Review>();
            Tags = new List<Tag>();
            Followers = new List<User>();
            Saves = new List<Save>();
            CreatedOn = DateTime.Now;
        }
    }
}