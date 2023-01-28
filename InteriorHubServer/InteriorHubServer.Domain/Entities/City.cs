namespace InteriorHubServer.Domain.Entities
{
    public class City
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public string Ua { get; set; }
        public string En { get; set; }

        public City() { }
        public City(string value, string en, string ua)
        {
            Value = value;
            En = en;
            Ua = ua;
        }
    }
}
