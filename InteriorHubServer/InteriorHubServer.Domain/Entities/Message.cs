namespace InteriorHubServer.Domain.Entities
{
    public class Message
    {
        public long Id { get; set; }
        public Dialog Dialog { get; set; }
        public long DialogId { get; set; }
        public User? Sender { get; set; }
        public long SenderId { get; set; }
        public string? Text { get; set; }
        public bool IsViewed { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
