﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Magxe.Data;
using Microsoft.EntityFrameworkCore;
using static Magxe.Constants;

namespace Magxe.Extensions
{
    internal static class DataContextTagExtension
    {
        private static readonly Lazy<DataContext> _dataContext;

        static DataContextTagExtension()
        {
            _dataContext = new Lazy<DataContext>(() => Config.ServiceProvider.GetService<DataContext>());
        }

        public static IQueryable<Tag> GetTagsByIds(this DbSet<Tag> dbSet, IEnumerable<int> tagIds)
        {
            return dbSet.Where(t => tagIds.Contains(t.Id));
        }

        public static async Task<(int totalPages, int totalPosts)> GetTagTotalPagesAsync(this DbSet<Tag> dbSet, int tagId)
        {
            var posts = await dbSet.GetTagTotalPostsAsync(tagId);
            var pages = (posts + PostPerPage - 1) / PostPerPage;
            return (pages, posts);
        }

        public static async Task<int> GetTagTotalPostsAsync(this DbSet<Tag> dbSet, int tagId)
        {
            return await Config.DataContext.PostTags.Where(row => row.TagId == tagId).CountAsync();
        }
    }
}