
using System.Net;
using UrlShortener.Utilities.Bitly.Models;

namespace UrlShortener.Utilities.Bitly.Exceptions
{
    public class BitlyRateLimitException : BitlyException
    {
        public BitlyRateLimitException(HttpStatusCode statusCode, BitlyErrorResponse error)
            : base(statusCode, error) { }
    }
}
