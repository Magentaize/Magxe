namespace Magxe.Controllers.Admin.Models
{
    public class ConfigurationItem
    {
        public bool UseGravatar { get; set; }
        public bool PublicApi { get; set; }
        public string BlogUrl { get; set; }
        public string BlogTitle { get; set; }
        public RouteKeywords RouteKeywords { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}