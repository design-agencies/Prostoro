namespace InteriorHubServer.Domain.Entities
{
    public class Dialog
    {
        public long Id { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<Message>? Messages { get; set; }
        public Dialog()
        {
            Users = new List<User>();
            Messages = new List<Message>();
        }
    }
}
