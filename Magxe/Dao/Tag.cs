using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;

namespace Magxe.Dao
{
    public class Tag : MetaItem<int>
    {
        public Tag()
        {
        }

        [NotMapped]
        public IEnumerable<Post> Posts => PostsTags.Select(r => r.Post);

        [JsonIgnore]
        public ICollection<PostTag> PostsTags { get; set; } = new HashSet<PostTag>();

        [Required]
        [StringLength(150)]
        public string Slug { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(150)]
        public string FeatureImage { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}