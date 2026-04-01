namespace UrlShortener.Utilities.Bitly.Models.Shorten
{
    public class BitlyShortenResponse
    {
        public Dictionary<string, object> References { get; set; }

        public string Link { get; set; }

        public string Id { get; set; }

        public string LongUrl { get; set; }

        public bool Archived { get; set; }

        public string CreatedAt { get; set; }

        public List<string> CustomBitlinks { get; set; }

        public List<string> Tags { get; set; }

        public List<BitlyDeepLink> Deeplinks { get; set; }
    }
}
