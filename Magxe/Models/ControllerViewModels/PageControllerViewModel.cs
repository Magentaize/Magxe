using Magxe.Controllers;
using Magxe.Views.Abstractions;

namespace Magxe.Models.ControllerViewModels
{
    public class PageControllerViewModel : MetaBaseModel, ISlug
    {
        #region Template Variables
        public BlogViewModel blog { get; set; }
        public string feature_image { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string slug { get; set; }
        #endregion
    }
}