using Magxe.Data;
using Magxe.Views.Abstractions;
using System;
using System.Collections.Generic;

namespace Magxe.Models
{
    internal class PostViewModel : IPost, IExcerpt
    {
        #region Template Variables
        public string slug { get; set; }
        public string title { get; set; }
        public IPostAuthor author { get; set; }
        public IEnumerable<Tag> tags { get; set; }
        public DateTime date { get; set; }
        public string excerpt { get; set; }
        #endregion

        public string Html { get; set; }
        public string CustomExcerpt { get; set; }
    }
}