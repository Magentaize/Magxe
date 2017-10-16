using Magxe.Data.Setting;

namespace Magxe.Models
{
    public class AuthorControllerViewModel : PostAuthorViewModel
    {
        public string cover_image { get; set; }
        public BlogViewModel blog { get; set; }
    }
}