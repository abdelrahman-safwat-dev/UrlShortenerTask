namespace UrlShortener.Utilities.Core.Entities
{
    public class ShortendUrl
    {
        public string Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortUrl { get; set; }
        public string UrlShortenerProvider { get; set; }
        public List<string> BackHalves { get; set; }
        public List<string> Tags { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
