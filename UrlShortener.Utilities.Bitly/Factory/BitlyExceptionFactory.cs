
using System.Net;
using UrlShortener.Utilities.Bitly.Exceptions;
using UrlShortener.Utilities.Bitly.Models;

namespace UrlShortener.Utilities.Bitly.Factory
{
    internal static class BitlyExceptionFactory
    {
        internal static Exception CreateBitlyException(HttpStatusCode statusCode, BitlyErrorResponse error)
        {
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:             //syntax wise
                case HttpStatusCode.UnprocessableEntity:    //semantic wise
                    return new BitlyBadRequestException(statusCode, error);
                
                case HttpStatusCode.Forbidden:              //unauthorized
                    return new BitlyForbiddenException(statusCode, error);

                case (HttpStatusCode)429: //monthly limit exception
                    return new BitlyRateLimitException(statusCode, error);
                
                //internal server errors
                case HttpStatusCode.InternalServerError:
                case HttpStatusCode.ServiceUnavailable:
                    return new BitlyServerException(statusCode, error);

                default:
                    return new BitlyException(statusCode, error);

                    //417 Expectation Failed is not handeled because I'm not sending any expect in the header requests.
            }
        }
    }
}
