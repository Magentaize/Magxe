using Newtonsoft.Json;

namespace Magxe.Data.Setting
{
    public class NavigationItem
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}