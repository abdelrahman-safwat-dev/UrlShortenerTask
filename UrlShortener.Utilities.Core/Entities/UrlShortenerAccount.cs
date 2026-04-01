namespace UrlShortener.Utilities.Core.Entities
{
    public class UrlShortenerAccount
    {
        public string UrlShortenerProvider { get; set; }
        
        public string Username { get; set; }

        public string AccessToken { get; set; }

        public int MonthlyShorteningLimit { get; set; }

        public int MonthlyShorteningUsage { get; set; }
                
    }
}
