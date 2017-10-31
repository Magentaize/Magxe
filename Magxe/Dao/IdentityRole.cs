using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magxe.Dao
{
    public class IdentityRole : IdentityRole<string>
    {
        public IdentityRole()
        {
            Id = Guid.NewGuid().ToString();
        }
    }

    public class IdentityRole<TKey> where TKey : IEquatable<TKey>
    {
        public IdentityRole()
        {
        }

        public IdentityRole(string name)
        {
            Name = name;
        }

        [Required]
        public virtual TKey Id { get; set; }

        [Required]
        [MaxLength(50)]
        public virtual string Name { get; set; }

        [Column(TypeName = "text")]
        [MaxLength(2000)]
        public virtual string Description { get; set; }

        public virtual TKey CreatedBy { get; set; }

        public virtual DateTime CreatedAt { get; set; }

        public virtual TKey UpdatedBy { get; set; }

        public virtual DateTime UpdatedAt { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}