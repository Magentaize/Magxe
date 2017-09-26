using System.Collections.Generic;

namespace Magxe.Data.Setting
{
    public class BlogModel
    {
        public string logo { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public IEnumerable<NavigationItem> navigation { get; set; }
    }
}