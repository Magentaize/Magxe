using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;

namespace Magxe.Data
{
    public class Post : MetaItem
    {
        [StringLength(150)]
        [Column(Order = 1)]
        public string Title { get; set; }

        [StringLength(150)]
        [Column(Order = 2)]
        public string Slug { get; set; }

        [Column(Order = 3)]
        public string Html { get; set; }

        [Column(Order = 4)]
        public string PlainText { get; set; }

        [Column(Order = 5)]
        public string MobileDoc { get; set; }

        [StringLength(150)]
        [Column(Order = 6)]
        public string FeatureImage { get; set; }

        #region Tags

        [NotMapped]
        public int[] Tags
        {
            get => JsonConvert.DeserializeObject<int[]>(TagsValue);
            set => JsonConvert.SerializeObject(value);
        }

        [Column("Tags")]
        public string TagsValue { get; set; }

        #endregion

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