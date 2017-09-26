using Magxe.Data.Setting;

namespace Magxe.Models
{
    public class PostModel
    {
        public BlogModel blog { get; set; }
        public int authorId { get; set; }
        public string feature_image { get; set; }
        public string title { get; set; }

    }
}