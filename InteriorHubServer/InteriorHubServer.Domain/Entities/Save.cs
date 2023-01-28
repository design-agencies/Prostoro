namespace InteriorHubServer.Domain.Entities
{
    public class Save
    {
        public long Id { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
        public string Folder { get; set; }
        public Project? Project { get; set; }
        public long? ProjectId { get; set; }
        public Agency? Agency { get; set; }
        public long? AgencyId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public Save() { }
        public Save(User user, Project project, string folder)
        {
            User = user;
            Project = project;
            Folder = folder;
        }
        public Save(User user, Agency agency, string folder)
        {
            User = user;
            Agency = agency;
            Folder = folder;
        }
    }
}
