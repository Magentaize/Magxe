using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magxe.Data
{
    public class Post : MetaItem
    {
        [StringLength(150)]
        public string Slug { get; set; }

        public string Html { get; set; }

        public string MobileDoc { get; set; }

        public string PlainText { get; set; }

        [StringLength(150)]
        public string FeatureImage { get; set; }

        public PostStatus Status { get; set; }

        public int AuthorId { get; set; }

        [Required]
        public DateTime CreatedTime { get; set; }

        [Required]
        public DateTime UpdatedTime { get; set; }

        public DateTime PublishedTime { get; set; }

        [Column(TypeName = "text")]
        public string CustomExcerpt { get; set; }

        public string CodeInjectionHead { get; set; }

        public string CodeInjectionFoot { get; set; }

        public enum PostStatus
        {
            Published,
            Draft
        }
    }
}