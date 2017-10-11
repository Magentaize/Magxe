using System;
using System.Collections.Generic;
using Magxe.Data;

namespace Magxe.Models
{
    internal class PostViewModel
    {
        public string url { get; set; }
        public string title { get; set; }
        public AuthorViewModel author { get; set; }
        public IEnumerable<Tag> tags { get; set; }
        public DateTime date { get; set; }
        public string excerpt { get; set; }

        internal string Html { get; set; }
        internal string CustomExcerpt { get; set; }
    }
}