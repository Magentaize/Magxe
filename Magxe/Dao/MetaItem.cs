using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magxe.Dao
{
    public class MetaItem : MetaItem<string>
    {        
    }

    public class MetaItem<TKey> : IdItem<TKey> where TKey:IEquatable<TKey>
    {
        [Column(TypeName = "varchar(50)")]
        public string MetaTitle { get; set; }

        [Column(TypeName = "text")]
        public string MetaDescription { get; set; }
    }
}