namespace InteriorHubServer.Domain.Contracts
{
    public class GetDialogsResponse
    {
        public long Id { get; set; }
        public DialogContact Contact { get; set; }
        public MessageDto LastMessage { get; set; }
        public int? UnviewedCount { get; set; }
        public class DialogContact
        {
            public long Id { get; set; }
            public string? AvatarImgUrl { get; set; }
            public string? Name { get; set; }
        }
    }

    public class MessageDto
    {
        public long Id { get; set; }
        public long DialogId { get; set; }
        //public long SenderId { get; set; }
        public string? Text { get; set; }
        public DateTime Date { get; set; }
        public bool IsCurrentUser { get; set; }
        public bool IsViewed { get; set; }
    }

    public class MessageCreateRequest
    {
        public long SenderId { get; set; }
        public long RecipientId { get; set; }
        public string? Text { get; set; }
    }
}
