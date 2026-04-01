
using System.Net;
using UrlShortener.Utilities.Bitly.Models;

namespace UrlShortener.Utilities.Bitly.Exceptions
{
    public class BitlyForbiddenException : BitlyException
    {
        public BitlyForbiddenException(HttpStatusCode statusCode, BitlyErrorResponse error)
            : base(statusCode, error) { }
    }
}
