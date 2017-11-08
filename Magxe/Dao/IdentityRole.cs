using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magxe.Dao
{
    public class IdentityRole : IdentityRole<string>
    {
        public IdentityRole()
        {
            Id = Guid.NewGuid().ToString("N");
        }
    }

    public class IdentityRole<TKey> where TKey : IEquatable<TKey>
    {
        public IdentityRole()
        {
        }

        public IdentityRole(string name) : this()
        {
            Name = name;
        }

        [Required]
        public TKey Id { get; set; }

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