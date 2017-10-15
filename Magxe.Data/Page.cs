﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magxe.Data
{
    public class Page : MetaItem
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

        public string CodeInjectionHead { get; set; }

        public string CodeInjectionFoot { get; set; }

        public bool IsPage { get; set; }

        public PostStatus Status { get; set; }

        public enum PostStatus
        {
            Published,
            Draft
        }
    }
}