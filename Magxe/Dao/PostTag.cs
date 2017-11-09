using Magxe.Data.Collection.Abstraction;

namespace Magxe.Dao
{
    public class PostTag : IdItem<int>, IJoinEntity<Post>, IJoinEntity<Tag>
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        Post IJoinEntity<Post>.Navigation
        {
            get => Post;
            set => Post = value;
        }

        public int TagId { get; set; }
        public Tag Tag { get; set; }

        Tag IJoinEntity<Tag>.Navigation
        {
            get => Tag;
            set => Tag = value;
        }
    }
}