namespace InteriorHubServer.Domain.Entities
{
    public class Like
    {
        public long Id { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
        public Project Project { get; set; }
        public long ProjectId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public Like() { }
        public Like(User user, Project project)
        {
            User = user;
            Project = project;
        }
    }
}
