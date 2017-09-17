using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magxe.Data
{
    public class User : MetaItem
    {
        [Required]
        [StringLength(150)]
        public string Slug { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(150)]
        public string ProfileImage { get; set; }

        [StringLength(150)]
        public string CoverImage { get; set; }

        [Column(TypeName = "text")]
        public string Bio { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        public DateTime LastLog { get; set; }

        [Required]
        public DateTime CreatedTime { get; set; }
    }
}