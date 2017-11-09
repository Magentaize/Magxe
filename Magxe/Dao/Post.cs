using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Magxe.Data.Collection;

namespace Magxe.Dao
{
    public class Post : Page
    {
#pragma warning disable CS0618
        public Post()
        {
            IsPage = false;

            Tags = new JoinCollectionFacade<Tag, Post, PostTag>(this, PostTags);
        }
#pragma warning restore CS0618

        public string AuthorId { get; set; }

        [Required]
        public DateTime CreatedTime { get; set; }

        [Required]
        public DateTime UpdatedTime { get; set; }

        public DateTime PublishedTime { get; set; }

        [Column(TypeName = "text")]
        public string CustomExcerpt { get; set; }

        [Obsolete("MANY-TO-MANY USAGE")]
        public ICollection<PostTag> PostTags { get; } = new HashSet<PostTag>();

        [NotMapped]
        public IEnumerable<Tag> Tags;
    }
}