using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Magxe.Dao
{
    public class IdentityUser : IdentityUser<string>
    {
    }

    public class IdentityUser<TKey> : MetaItem<TKey> where TKey : IEquatable<TKey>
    {
        [NotMapped]
        public ICollection<Role> Roles { get; set; }

        [Required]
        [StringLength(200)]
        [IgnoreDataMember]
        public string Password { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Slug { get; set; }

        [StringLength(150)]
        public string ProfileImage { get; set; }

        [StringLength(150)]
        public string CoverImage { get; set; }

        [Column(TypeName = "text")]
        public string Bio { get; set; }

        public UserStatus Status { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        public DateTime LastSeen { get; set; }

        [Required]
        public DateTime CreatedTime { get; set; }

        [StringLength(50)]
        public string Website { get; set; }
    }
}