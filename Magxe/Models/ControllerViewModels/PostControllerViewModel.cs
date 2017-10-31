using Magxe.Views.Abstractions;
using System.Collections.Generic;
using Magxe.Dao;

namespace Magxe.Models.ControllerViewModels
{
    public class PostControllerViewModel : PageControllerViewModel, ITags, IAuthor
    {
        public string AuthorId { get; set; }

        #region Template Variables
        public IEnumerable<Tag> tags { get; set; }
        #endregion
    }
}