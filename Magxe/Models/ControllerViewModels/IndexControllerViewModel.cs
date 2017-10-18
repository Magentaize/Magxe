using System;
using System.Collections.Generic;
using Magxe.Views.Abstractions;

namespace Magxe.Models.ControllerViewModels
{
    internal class IndexControllerViewModel : MetaBaseModel, IPostLoop, IBlog, IPaged
    {
        public BlogViewModel blog { get; set; }
        public IEnumerable<IPost> posts { get; set; }
        public (int TotalPages, int CurrentPage) PageInfo { get; set; }
        public bool IsPaged { get; set; }
    }
}