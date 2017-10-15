using Magxe.Controllers;
using Magxe.Helpers.Abstractions;

namespace Magxe.Models
{
    public class PageViewModel : IControllerType, ISlug
    {
        public ControllerType ControllerType { get; set; }

        #region Template Variables
        public BlogViewModel blog { get; set; }
        public string feature_image { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string slug { get; set; }
        #endregion
    }
}