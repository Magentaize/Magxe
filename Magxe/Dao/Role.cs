using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Magxe.Dao
{
    public class Role : IdItem
    {
        public Role()
        {
            Id = Guid.NewGuid().ToString("N");
        }

        public Role(string name) : this()
        {
            Name = name;
        }

        [JsonIgnore]
        public virtual ICollection<UserRole> UsersRoles { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        [MaxLength(200)]
        public string Description { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}