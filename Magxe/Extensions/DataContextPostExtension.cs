using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Magxe.Data;
using Microsoft.EntityFrameworkCore;
using static Magxe.Constants;

namespace Magxe.Extensions
{
    internal static class DataContextPostExtension
    {
        public static IEnumerable<Post> GetPagePosts(this DbSet<Post> dbSet, int pageIndex)
        {
            return dbSet.GetOrderedPosts().Skip((pageIndex - 1) * PostPerPage).Take(PostPerPage);
        }

        public static IEnumerable<Post> GetAuthorPagePosts(this DbSet<Post> dbSet, int pageIndex, int authorId)
        {
            return dbSet.GetOrderedPosts().Where(p => p.AuthorId == authorId).Skip((pageIndex - 1) * PostPerPage)
                .Take(PostPerPage);
        }

        public static IEnumerable<Post> GetOrderedPosts(this DbSet<Post> dbSet)
        {
            return dbSet.OrderByDescending(p => p.PublishedTime);
        }

        public static async Task<int> GetTotalPagesAsync(this DbSet<Post> dbSet)
        {
            return (await dbSet.CountAsync() + PostPerPage - 1) / PostPerPage;
        }

        public static async Task<(int totalPages, int totalPosts)> GetAuthorTotalPagesAsync(this DbSet<Post> dbSet, int authorId)
        {
            var posts = await dbSet.GetAuthorTotalPostsAsync(authorId);
            var pages = (posts + PostPerPage - 1) / PostPerPage;
            return (pages, posts);
        }

        public static async Task<int> GetAuthorTotalPostsAsync(this DbSet<Post> dbSet, int authorId)
        {
            return await dbSet.Where(p => p.AuthorId == authorId).CountAsync();
        }
    }
}