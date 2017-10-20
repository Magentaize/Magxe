using Magxe.Controllers;
using Magxe.Views.Abstractions;
using System;
using System.Collections.Generic;

namespace Magxe.Models
{
    internal class TagControllerViewModel : IPostLoop, IBlog, IControllerType, IPlural, IPaged, ISlug
    {
        //public TagViewModel tag { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; } = DateTime.Now;
        public BlogViewModel blog { get; set; }
        public IEnumerable<IPost> posts { get; set; }
        public (int TotalPages, int CurrentPage) PageInfo { get; set; }
        public ControllerType ControllerType { get; set; }
        public int PluralNumber { get; set; }
        public bool IsPaged { get; set; }
        public string slug { get; set; }

        public class TagViewModel
        {
            public string feature_image { get; set; }
        }
    }
}