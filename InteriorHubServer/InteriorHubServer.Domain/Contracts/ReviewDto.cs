namespace InteriorHubServer.Domain.Contracts
{
    public class ReviewDto
    {
        public long Id { get; set; }
        public string? UserName { get; set; }
        public long UserId { get; set; }
        //public long AgencyId { get; set; }
        public string? Message { get; set; }
        public int Rate { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class CreateReviewRequest
    {
        public long AgencyId { get; set; }
        public string? Message { get; set; }
        public int Rate { get; set; }
    }

    public class CreateComplaintRequest
    {
        public long ReviewId { get; set; }
        public string? ComplaintReason { get; set; }
        public string? Message { get; set; }
    }
}
