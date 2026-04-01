using UrlShortener.Utilities.Core.DTOs;
using UrlShortener.Utilities.Core.Entities;

namespace UrlShortener.Utilities.Core.Interfaces
{
    public interface IUrlShortenerService
    {
        public Task<ShortendUrl> ShortenUrl(ShortenRequest request);
    }
}
