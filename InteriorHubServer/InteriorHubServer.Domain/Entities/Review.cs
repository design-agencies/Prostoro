namespace InteriorHubServer.Domain.Entities
{
    public class Review
    {
        public long Id { get; set; }
        public User? User { get; set; }
        public long UserId { get; set; }
        public string? UserName { get; set; }
        public Agency? Agency { get; set; }
        public long AgencyId { get; set; }
        public string? Message { get; set; }
        public int Rate { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public ICollection<Complaint>? Complaints { get; set; }
        public Review()
        {
            Complaints = new List<Complaint>();
        }
    }
}
