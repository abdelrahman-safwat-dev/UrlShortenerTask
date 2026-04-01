
using System.Net;
using UrlShortener.Utilities.Bitly.Models;

namespace UrlShortener.Utilities.Bitly.Exceptions
{
    public class BitlyServerException : BitlyException
    {
        public BitlyServerException(HttpStatusCode statusCode, BitlyErrorResponse error)
            : base(statusCode, error) { }
    }
}
