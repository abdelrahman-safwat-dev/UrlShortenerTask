
using System.Net;
using UrlShortener.Utilities.Bitly.Models;

namespace UrlShortener.Utilities.Bitly.Exceptions
{
    public class BitlyBadRequestException : BitlyException
    {
        public BitlyBadRequestException(HttpStatusCode statusCode, BitlyErrorResponse error)
            : base(statusCode, error)
        {
        }
    }
}
