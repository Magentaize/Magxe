using System;

namespace Magxe.Models
{
    public class PostAuthorViewModel
    {
        public string profile_image { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string bio { get; set; }

        [Obsolete("Only be compatible with Ghost", true)]
        public string website { get; private set; }
    }
}