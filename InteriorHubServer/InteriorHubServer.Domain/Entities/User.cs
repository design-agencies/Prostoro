using Microsoft.AspNetCore.Identity;

namespace InteriorHubServer.Domain.Entities
{
    public class User : IdentityUser<long> // TODO constructor, int
    {
        public string? Location { get; set; } = default!;
        public Image? Photo { get; set; } = default!;
        public DateTime RegisteredOn { get; set; } = DateTime.Now;
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        //public bool IsVerified { get; set; } = false;
        //public DateTime LastActivity { get; set; } = DateTime.Now;
        public NotificationSettings NotificationSettings { get; set; }
        public long? NotificationSettingsId { get; set; }
        public ICollection<Message>? Messages { get; set; }
        public ICollection<Dialog>? Dialogs { get; set; }
        public ICollection<Agency>? Follows { get; set; }
        public Agency? Agency { get; set; }
        //public long? AgencyId { get; set; }

        public User() : base()
        {
            Messages = new List<Message>();
            Dialogs = new List<Dialog>();
            Follows = new List<Agency>();
            NotificationSettings = new NotificationSettings();
        }
    }
}
