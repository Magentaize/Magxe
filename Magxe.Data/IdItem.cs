using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magxe.Data
{
    public class IdItem
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
    }
}