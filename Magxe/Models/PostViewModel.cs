using Magxe.Controllers;
using Magxe.Data;
using Magxe.Helpers.Abstractions;
using System.Collections.Generic;

namespace Magxe.Models
{
    public class PostViewModel : PageViewModel, ITags, IAuthor
    {
        public int AuthorId { get; set; }

        #region Template Variables
        public IEnumerable<Tag> tags { get; set; }
        #endregion
    }
}