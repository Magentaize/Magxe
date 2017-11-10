using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Magxe.Data.Collection.Abstraction;

namespace Magxe.Dao
{
    [Table("Posts_Tags")]
    public class PostTag : IdItem<int>, IJoinEntity<Post>, IJoinEntity<Tag>
    {
        [Required]
        public Post Post { get; set; }
        Post IJoinEntity<Post>.Navigation
        {
            get => Post;
            set => Post = value;
        }

        [Required]
        public Tag Tag { get; set; }
        Tag IJoinEntity<Tag>.Navigation
        {
            get => Tag;
            set => Tag = value;
        }
    }
}