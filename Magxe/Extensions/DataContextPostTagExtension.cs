using System;
using System.Linq;
using Magxe.Data;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Extensions
{
    internal static class DataContextPostTagExtension
    {
        public static IQueryable<Post> GetPagedPostsByTagId(this DbSet<PostTag> dbSet, int tagId, int pageIndex)
        {
            return dbSet.Include(pt => pt.Post).Where(row => row.TagId == tagId).Select(pt => pt.Post).PagingPosts(pageIndex);
        }

        public static IQueryable<Tag> GetTagsByPostId(this DbSet<PostTag> dbSet, int postId)
        {
            return dbSet.Include(pt => pt.Tag).Where(row => row.PostId == postId).Select(pt => pt.Tag);
        }
    }
}