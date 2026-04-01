using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Utilities.Bitly.Models
{
    public class BitlyOptions
    {
        public const string Bitly = "Bitly";
        public string BaseUrl { get; set; } = "https://api-ssl.bitly.com/";
        public string AccessToken { get; set; } = string.Empty;
    }
}
