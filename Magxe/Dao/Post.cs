using Magxe.Data.Collection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magxe.Dao
{
    public class Post : Page
    {
        public Post()
        {
            IsPage = false;
            Tags = new JoinCollectionFacade<Tag, Post, PostTag>(this, PostsTags);
        }

        [NotMapped]
        public ICollection<Tag> Tags { get; }

        [JsonIgnore]
        public ICollection<PostTag> PostsTags { get; set; } = new List<PostTag>();

        public string AuthorId { get; set; }

        [Required]
        public DateTime CreatedTime { get; set; }

        [Required]
        public DateTime UpdatedTime { get; set; }

        public DateTime PublishedTime { get; set; }

        [Column(TypeName = "text")]
        public string CustomExcerpt { get; set; }
    }
}