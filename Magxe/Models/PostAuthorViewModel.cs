using System;
using Magxe.Views.Abstractions;

namespace Magxe.Models
{
    internal class PostAuthorViewModel : IPostAuthor
    {
        public string profile_image { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string bio { get; set; }
        public string website { get; private set; }
    }
}