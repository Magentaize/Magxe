using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace Magxe.Data
{
    public class Setting
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Key Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Value { get; set; }

        public enum Key
        {
            DisplayUpdateNotification = 0,
            Title = 1,
            Description = 2,
            CoverImage = 3,
            Icon = 4,
            Favicon = 5,
            Logo = 6,
            TimeZone = 7,
            Navigation = 8,
            Theme = 9,
            CodeInjectionHead = 10,
            CodeInjectionFoot = 11,
        }
    }
}
