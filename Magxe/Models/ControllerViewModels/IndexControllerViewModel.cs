using System;
using System.Collections.Generic;
using Magxe.Views.Abstractions;

namespace Magxe.Models.ControllerViewModels
{
    internal class IndexControllerViewModel : MetaBaseModel, IPostLoop
    {
        public DateTime date { get; set; }
        public BlogViewModel blog { get; set; }
        public IEnumerable<IPost> posts { get; set; }
    }
}