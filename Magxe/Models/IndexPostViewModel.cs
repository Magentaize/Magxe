using Magxe.Data;
using Magxe.Helpers.Abstractions;
using System;
using System.Collections.Generic;

namespace Magxe.Models
{
    internal class IndexPostViewModel : ITags
    {
        #region Template Variables
        public string url { get; set; }
        public string title { get; set; }
        public PostAuthorViewModel author { get; set; }
        public IEnumerable<Tag> tags { get; set; }
        public DateTime date { get; set; }
        public string excerpt { get; set; }
        #endregion

        internal string Html { get; set; }
        internal string CustomExcerpt { get; set; }
    }
}