namespace InteriorHubServer.Domain.Entities
{
    public class Complaint
    {
        public long Id { get; set; }
        public Review? Review { get; set; }
        public long ReviewId { get; set; }
        public User? User { get; set; }
        public long UserId { get; set; }
        public string? ComplaintReason { get; set; }
        public string? Message { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
