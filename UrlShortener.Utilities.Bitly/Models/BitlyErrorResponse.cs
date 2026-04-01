
namespace UrlShortener.Utilities.Bitly.Models
{
    public class BitlyErrorResponse
    {
        public string Message { get; set; }
        public string Description { get; set; }
        public string Resource { get; set; }
        public List<BitlyErrorDetail> Errors { get; set; }
    }
}
