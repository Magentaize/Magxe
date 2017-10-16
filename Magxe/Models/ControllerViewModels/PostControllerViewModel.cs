using Magxe.Controllers;
using Magxe.Data;
using Magxe.Views.Abstractions;
using System.Collections.Generic;

namespace Magxe.Models.ControllerViewModels
{
    public class PostControllerViewModel : PageControllerViewModel, ITags, IAuthor
    {
        public int AuthorId { get; set; }

        #region Template Variables
        public IEnumerable<Tag> tags { get; set; }
        #endregion
    }
}