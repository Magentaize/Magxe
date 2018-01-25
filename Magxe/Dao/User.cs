using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Magxe.Dao
{
    public class User : MetaItem
    {
        public User()
        {
            Id = Guid.NewGuid().ToString("N");
        }

        [NotMapped]
        [JsonProperty("roles")]
        public IEnumerable<Role> Roles => UsersRoles.Select(r => r.Role);

        [JsonIgnore]
        public ICollection<UserRole> UsersRoles { get; set; } = new HashSet<UserRole>();

        [JsonIgnore]
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();

        [JsonIgnore]
        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();

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

        [Required]
        public DateTime LastSeen { get; set; }

        [Required]
        public DateTime CreatedTime { get; set; }

        [StringLength(50)]
        public string Website { get; set; }
    }
}