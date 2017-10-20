using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magxe.Data
{
    public class Post : Page
    {
        public Post()
        {
            IsPage = false;
        }

        [Column("Tags")]
        public List<PostTag> PostTags { get; set; }

        public int AuthorId { get; set; }

        [Required]
        public DateTime CreatedTime { get; set; }

        [Required]
        public DateTime UpdatedTime { get; set; }

        public DateTime PublishedTime { get; set; }

        [Column(TypeName = "text")]
        public string CustomExcerpt { get; set; }
    }
}