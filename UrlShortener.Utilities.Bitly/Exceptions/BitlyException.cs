
using System.Net;
using UrlShortener.Utilities.Bitly.Models;

namespace UrlShortener.Utilities.Bitly.Exceptions
{
    public class BitlyException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public string Description { get; }
        public string Resource { get; }
        public List<BitlyErrorDetail> Errors { get; }

        public BitlyException(HttpStatusCode statusCode, BitlyErrorResponse error)
            : base(error?.Message)
        {
            StatusCode = statusCode;
            Description = error?.Description;
            Resource = error?.Resource;
            Errors = error?.Errors ?? new List<BitlyErrorDetail>();
        }
    }
}
