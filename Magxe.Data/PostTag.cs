using System.ComponentModel.DataAnnotations;

namespace Magxe.Data
{
    public class PostTag
    {
        [Key]
        public int PostId { get; set; }
        [Key]
        public int TagId { get; set; }
        public Post Post { get; set; }
        public Tag Tag { get; set; }
    }
}