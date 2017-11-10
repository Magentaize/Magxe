using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;

namespace Magxe.Dao
{
    public class Post : Page
    {
        public Post()
        {
            IsPage = false;
        }

        [NotMapped]
        public IEnumerable<Tag> Tags => PostsTags.Select(r => r.Tag);

        [JsonIgnore]
        public ICollection<PostTag> PostsTags { get; set; } = new HashSet<PostTag>();

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