using Magxe.Dao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Magxe.Constants;

namespace Magxe.Extensions
{
    internal static class DataContextPostExtension
    {
        private static readonly Lazy<DataContext> _dataContext;

        static DataContextPostExtension()
        {
            _dataContext = new Lazy<DataContext>(() => Config.ServiceProvider.GetService<DataContext>());
        }

        public static IQueryable<Post> PagingPosts(this IQueryable<Post> posts, int pageIndex)
        {
            return posts.OrderByDescending(p => p.PublishedTime).Skip((pageIndex - 1) * PostPerPage).Take(PostPerPage);
        }

        public static IQueryable<Post> GetPagedPosts(this DbSet<Post> dbSet, int pageIndex)
        {
            return dbSet.PagingPosts(pageIndex);
        }

        public static IQueryable<Post> GetAuthorPagedPosts(this DbSet<Post> dbSet, int pageIndex, string authorId)
        {
            return dbSet.Where(p => p.AuthorId == authorId).PagingPosts(pageIndex);
        }

        public static async Task<int> GetTotalPagesAsync(this DbSet<Post> dbSet)
        {
            return (await dbSet.CountAsync() + PostPerPage - 1) / PostPerPage;
        }

        public static async Task<(int totalPages, int totalPosts)> GetAuthorTotalPagesAsync(this DbSet<Post> dbSet,
            string authorId)
        {
            var posts = await dbSet.GetAuthorTotalPostsAsync(authorId);
            var pages = (posts + PostPerPage - 1) / PostPerPage;
            return (pages, posts);
        }

        public static async Task<int> GetAuthorTotalPostsAsync(this DbSet<Post> dbSet, string authorId)
        {
            return await dbSet.Where(p => p.AuthorId == authorId).CountAsync();
        }

        public static IEnumerable<Tag> GetTags(this Post post)
        {
            var o = Config.DataContext.PostTags
                .Include(pt => pt.Post)
                .Include(pt => pt.Tag)
                .Where(p => p.PostId == post.Id)
                .Select(pt => pt.Tag).ToList();
            return o;
        }
    }
}