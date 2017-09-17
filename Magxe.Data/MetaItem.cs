using System.ComponentModel.DataAnnotations.Schema;

namespace Magxe.Data
{
    public class MetaItem : IdItem
    {
        [Column(TypeName = "varchar(50)")]
        public string MetaTitle { get; set; }

        [Column(TypeName = "text")]
        public string MetaDescription { get; set; }
    }
}