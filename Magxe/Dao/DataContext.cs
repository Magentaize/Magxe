using Magxe.Dao.Setting;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Dao
{
    public class DataContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DataContext()
        {            
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<SettingItem> Settings { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<RefreshToken>(b =>
            {
                b.HasKey(r => r.Key);
                b.HasIndex(r => r.Key).IsUnique();
                b.HasIndex(r => r.UserId);
                b.HasIndex(r => r.ClientId);

                b.HasOne(r => r.Client).WithMany(r => r.RefreshTokens).HasForeignKey(r => r.ClientId)
                    .OnDelete(DeleteBehavior.Cascade);
                b.HasOne(r => r.User).WithMany(r => r.RefreshTokens).HasForeignKey(r => r.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<PostTag>(b =>
            {
                b.ToTable("Posts_Tags");

                b.HasIndex(r => r.PostId);
                b.HasIndex(r => r.TagId);

                b.HasOne(r => r.Post).WithMany(r => r.PostTags).HasForeignKey(r => r.PostId)
                    .OnDelete(DeleteBehavior.Restrict);
                b.HasOne(r => r.Tag).WithMany(r => r.PostTags).HasForeignKey(r => r.TagId)
                    .OnDelete(DeleteBehavior.Restrict);
            });       
        }

        //private const string DbS =
        //        "Server=localhost;database=Magxe;port=3306;charset=UTF8;uid=root;pwd=;convert zero datetime=True"
        //    ;
        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    builder.UseMySql(DbS);
        //}
    }
}