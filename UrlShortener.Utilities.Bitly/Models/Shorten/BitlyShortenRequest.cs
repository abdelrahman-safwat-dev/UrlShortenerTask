namespace UrlShortener.Utilities.Bitly.Models.Shorten
{
    public class BitlyShortenRequest
    {
        public string LongUrl { get; set; }
        public string Domain { get; set; }
        public string GroupGuid { get; set; }
        public bool ForceNewLink { get; set; }
    }
}
