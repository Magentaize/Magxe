using System.Collections.Generic;
using Magxe.Data.Setting;

namespace Magxe.Models
{
    public class BlogViewModel
    {
        public string cover_image { get; set; }
        public string logo { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public IEnumerable<NavigationItem> navigation { get; set; }
    }
}