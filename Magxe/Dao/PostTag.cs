using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magxe.Dao
{
    [Table("Posts_Tags")]
    public class PostTag : IdItem<int>
    {
        [Required]
        public Post Post { get; set; }

        [Required]
        public Tag Tag { get; set; }
    }
}