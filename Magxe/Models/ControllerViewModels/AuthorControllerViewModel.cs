using Magxe.Controllers;
using Magxe.Views.Abstractions;
using System;
using System.Collections.Generic;

namespace Magxe.Models.ControllerViewModels
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