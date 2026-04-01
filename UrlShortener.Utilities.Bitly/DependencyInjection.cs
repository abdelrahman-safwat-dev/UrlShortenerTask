using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using UrlShortener.Utilities.Bitly.Models;
using UrlShortener.Utilities.Bitly.Services;
using UrlShortener.Utilities.Core.Interfaces;

namespace UrlShortener.Utilities.Bitly
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBitly(this IServiceCollection services)
        {
            services.AddOptions<BitlyOptions>()
                    .BindConfiguration(BitlyOptions.Bitly);

            services.AddHttpClient<IUrlShortenerService, BitlyUrlShortenerService>()
                .ConfigureHttpClient((sp, client) =>
                {
                    var options = sp.GetRequiredService<IOptions<BitlyOptions>>().Value;
                    client.BaseAddress = new Uri(options.BaseUrl);
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", options.AccessToken);
                });

            return services;
        }
    }
}
