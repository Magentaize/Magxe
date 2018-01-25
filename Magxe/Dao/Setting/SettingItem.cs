using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magxe.Dao.Setting
{
    public class SettingItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Key Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
