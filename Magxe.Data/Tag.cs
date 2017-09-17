using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magxe.Data
{
    public class Tag : MetaItem
    {
        [Required]
        [StringLength(150)]
        public string Slug { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(150)]
        public string FeatureImage { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}