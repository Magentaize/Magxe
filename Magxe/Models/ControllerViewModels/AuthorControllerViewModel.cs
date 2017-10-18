using System;
using System.Collections.Generic;
using Magxe.Controllers;
using Magxe.Data.Setting;
using Magxe.Views.Abstractions;

namespace Magxe.Models
{
    internal class AuthorControllerViewModel : PostAuthorViewModel, IPostLoop, IBlog, IControllerType, IPlural, IPaged
    {
        public string cover_image { get; set; }
        public DateTime date { get; set; } = DateTime.Now;
        public BlogViewModel blog { get; set; }
        public IEnumerable<IPost> posts { get; set; }
        public (int TotalPages, int CurrentPage) PageInfo { get; set; }
        public ControllerType ControllerType { get; set; }
        public int PluralNumber { get; set; }
        public bool IsPaged { get; set; }
    }
}