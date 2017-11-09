using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Magxe.Data.Collection;

namespace Magxe.Dao
{
    public class Tag : MetaItem<int>
    {
#pragma warning disable CS0618
        public Tag()
        {
            Posts = new JoinCollectionFacade<Post, Tag, PostTag>(this, PostTags);
        }
#pragma warning restore CS0618

        [Required]
        [StringLength(150)]
        public string Slug { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(150)]
        public string FeatureImage { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Obsolete("MANY-TO-MANY USAGE")]
        public ICollection<PostTag> PostTags { get; } = new HashSet<PostTag>();

        [NotMapped]
        public IEnumerable<Post> Posts;
    }
}