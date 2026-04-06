using System.Text.Json.Serialization;

namespace UrlShortener.Utilities.Bitly.Models.Shorten
{
    public class BitlyShortenResponse
    {
        public Dictionary<string, object> References { get; set; } // Reference data like group: gives you a url endpoint to get group information

        public string Link { get; set; }

        public string Id { get; set; }

        public string LongUrl { get; set; }

        public bool Archived { get; set; }

        public string CreatedAt { get; set; }

        public List<string> CustomBitlinks { get; set; }    //custom Backhalves or custom domains or both

        public List<string> Tags { get; set; }              // just a way to organize links

        public List<BitlyDeepLink> Deeplinks { get; set; }  // list to support more than one operating system
    }
}
