using Magxe.Helpers.Abstractions;

namespace Magxe.Models
{
    internal class NavigationViewModelItem : ISlug
    {
        public bool current { get; set; }
        public string label { get; set; }
        public string slug { get; set; }
        public bool secure { get; set; }
    }
}