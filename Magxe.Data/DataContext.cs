using System;
using Magxe.Data.Setting;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<SettingItem> Settings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        private const string DbS =
                "Server=localhost;database=Magxe;port=3306;charset=UTF8;uid=root;pwd=;convert zero datetime=True"
            ;
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySql(DbS);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PostTag>().HasKey(pt => new {pt.PostId, pt.TagId});
            builder.Entity<PostTag>().HasOne(pt => pt.Post).WithMany(p => p.PostTags).HasForeignKey(pt => pt.PostId);
            builder.Entity<PostTag>().HasOne(pt => pt.Tag).WithMany(t => t.PostTags).HasForeignKey(pt => pt.TagId);
        }
    }
}