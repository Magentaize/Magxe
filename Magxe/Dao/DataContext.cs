using Magxe.Dao.Setting;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Dao
{
    public class DataContext:IdentityDbContext<User, IdentityRole, string>
    {
        public DataContext()
        {            
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<SettingItem> Settings { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PostTag>().HasKey(pt => new { pt.PostId, pt.TagId });
            builder.Entity<PostTag>().HasOne(pt => pt.Post).WithMany(p => p.PostTags).HasForeignKey(pt => pt.PostId);
            builder.Entity<PostTag>().HasOne(pt => pt.Tag).WithMany(t => t.PostTags).HasForeignKey(pt => pt.TagId);
        }

        private const string DbS =
                "Server=localhost;database=Magxe;port=3306;charset=UTF8;uid=root;pwd=;convert zero datetime=True"
            ;
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySql(DbS);
        }
    }
}