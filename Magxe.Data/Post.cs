using Newtonsoft.Json;
using System;
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