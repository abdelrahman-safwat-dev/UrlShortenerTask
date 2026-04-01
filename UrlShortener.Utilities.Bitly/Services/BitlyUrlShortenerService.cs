using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using UrlShortener.Utilities.Bitly.Factory;
using UrlShortener.Utilities.Bitly.Models;
using UrlShortener.Utilities.Bitly.Models.Shorten;
using UrlShortener.Utilities.Core.DTOs;
using UrlShortener.Utilities.Core.Entities;
using UrlShortener.Utilities.Core.Interfaces;

namespace UrlShortener.Utilities.Bitly.Services
{
    public class BitlyUrlShortenerService : IUrlShortenerService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<BitlyUrlShortenerService> _logger;
        private static readonly JsonSerializerOptions _serializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };

        public BitlyUrlShortenerService(HttpClient httpClient, ILogger<BitlyUrlShortenerService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }


        private async Task<TSuccess> SendHttpRequest<TSuccess>(HttpMethod method, string endpoint, object requestBody = null)
        {
            using var request = new HttpRequestMessage(method, endpoint);

            if (requestBody != null)
            {
                request.Content = new StringContent(
                    JsonSerializer.Serialize(requestBody, _serializerOptions),
                    Encoding.UTF8,
                    "application/json");
            }

            HttpResponseMessage response;

            try
            {
                response = await _httpClient.SendAsync(request);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Network error calling Bitly API");
                throw;
            }

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                BitlyErrorResponse error;

                try
                {
                    error = JsonSerializer.Deserialize<BitlyErrorResponse>(content, _serializerOptions);
                }
                catch (JsonException ex)
                {
                    _logger.LogError(ex, "Failed to deserialize Bitly error response: {Content}", content);
                    throw;
                }
                _logger.LogError("Bitly API Error: {StatusCode} - {Message}", response.StatusCode, error != null ? error.Message : "Unknown");
                throw BitlyExceptionFactory.CreateBitlyException(response.StatusCode, error);
            }

            try
            {
                return JsonSerializer.Deserialize<TSuccess>(content, _serializerOptions);
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize Bitly response: {Content}", content);
                throw;
            }
        }

        public async Task<ShortendUrl> ShortenUrl(ShortenRequest shortenRequest)
        {
            var request = new BitlyShortenRequest
            {
                LongUrl = shortenRequest.LongUrl,
                Domain = shortenRequest.Domain
            };

            var result = await SendHttpRequest<BitlyShortenResponse>(HttpMethod.Post, "v4/shorten", request);

            return new ShortendUrl
            {
                OriginalUrl = result.LongUrl,
                ShortUrl = result.Link,
                UrlShortenerProvider = "Bitly",
                BackHalves = result.CustomBitlinks,
                Tags = result.Tags,
                CreatedAt = DateTimeOffset.Parse(result.CreatedAt)
            };
        }


    }
}
