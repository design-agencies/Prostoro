namespace InteriorHubServer.Domain.Entities
{
    public class Tag
    {
        public long Id { get; set; }
        public string? Value { get; set; }
        public string? Type { get; set; }
        public string? En { get; set; }
        public string? Ua { get; set; }

        public Tag() {}
        public Tag(string value, string type, string en, string ua)
        {
            Value = value;
            Type = type;
            En = en;
            Ua = ua;
        }
    }
}
