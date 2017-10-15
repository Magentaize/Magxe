using System;
using Magxe.Helpers.Abstractions;

namespace Magxe.Models
{
    public class PostAuthorViewModel : ISlug
    {
        public string profile_image { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string bio { get; set; }

        [Obsolete("Only be compatible with Ghost", true)]
        public string website { get; private set; }
    }
}