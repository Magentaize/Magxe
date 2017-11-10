using Magxe.Dao;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Magxe.Extensions
{
    internal static class DataContextPostTagExtension
    {
        public static IQueryable<Post> GetPagedPostsByTagId(this DbSet<PostTag> dbSet, int tagId, int pageIndex)
        {
            return dbSet.Include(pt => pt.Post).Where(row => row.Tag.Id == tagId).Select(pt => pt.Post).PagingPosts(pageIndex);
        }

        public static IQueryable<Tag> GetTagsByPostId(this DbSet<PostTag> dbSet, int postId)
        {
            return dbSet.Include(pt => pt.Tag).Where(row => row.Post.Id == postId).Select(pt => pt.Tag);
        }
    }
}