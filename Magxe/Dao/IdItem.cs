using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magxe.Dao
{
    public class IdItem : IdItem<string>
    {
        public IdItem()
        {
            Id = Guid.NewGuid().ToString("N");
        }
    }

    public class IdItem<TKey> where TKey : IEquatable<TKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public TKey Id { get; set; }
    }
}