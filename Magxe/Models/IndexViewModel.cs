using System.Collections.Generic;

namespace Magxe.Models
{
    internal class IndexViewModel : MetaBaseModel
    {
        public BlogViewModel blog { get; set; }
        public IEnumerable<IndexPostViewModel> posts { get; set; }
    }
}