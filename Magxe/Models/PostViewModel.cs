using Magxe.Controllers;
using Magxe.Data;
using Magxe.Helpers.Abstractions;
using System.Collections.Generic;

namespace Magxe.Models
{
    public class PostViewModel : ITags, IAuthor, IControllerType
    {
        public ControllerType ControllerType { get; set; }
        public int AuthorId { get; set; }

        #region Template Variables
        public BlogViewModel blog { get; set; }
        public string feature_image { get; set; }
        public string title { get; set; }
        public IEnumerable<Tag> tags { get; set; }
        public string content { get; set; }
        public string url { get; set; }
        #endregion
    }
}