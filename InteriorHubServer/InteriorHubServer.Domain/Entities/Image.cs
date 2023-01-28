namespace InteriorHubServer.Domain.Entities
{
    public class Image
    {
        public long Id { get; set; }
        public string? Url { get; set; }
        public string? Code { get; set; }

        public Image() {}

        public Image(string url, string code = "")
        {
            Url = url;
            Code = code;
        }
    }
}
