namespace UrlShortener.Utilities.Bitly.Models
{
    public class BitlyDeepLink
    {
        public string Guid { get; set; }

        public string Bitlink { get; set; }

        public string AppUriPath { get; set; }  

        public string InstallUrl { get; set; }  //if the app is not installed, send the user to install it

        public string AppGuid { get; set; }     // like an id for the app

        public string Os { get; set; }          //example: iOS or Android

        public string InstallType { get; set; } //whether to force the user to install the app or not.

        public string Created { get; set; }

        public string Modified { get; set; }

        public string BrandGuid { get; set; }  // like an id for a specific custom domain.
    }
}