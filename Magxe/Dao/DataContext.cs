using Magxe.Dao.Setting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Dao
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<IdentityRoleClaim<string>> RoleClaims { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<IdentityUserClaim<string>> UserClaims { get; set; }
        public DbSet<IdentityUserLogin<string>> UserLogins { get; set; }
        public DbSet<IdentityUserToken<string>> UserTokens { get; set; }

        public DbSet<SettingItem> Settings { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(b =>
            {
                b.HasKey(u => u.Id);
                b.HasIndex(u => u.Slug).HasName("users_slug_unique").IsUnique();
                b.HasIndex(u => u.Email).HasName("users_email_unique").IsUnique();
                b.ToTable("Users");

                // Replace with b.HasMany<IdentityUserClaim>().
                b.HasMany<IdentityUserClaim<string>>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
                b.HasMany<IdentityUserLogin<string>>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
                b.HasMany<IdentityUserToken<string>>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
            });

            builder.Entity<IdentityUserClaim<string>>(b =>
            {
                b.HasKey(uc => uc.Id);
                b.ToTable("Users_Claims");
            });

            builder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.HasKey(l => new {l.LoginProvider, l.ProviderKey});
                b.ToTable("Users_Logins");
            });

            builder.Entity<IdentityUserToken<string>>(b =>
            {
                b.HasKey(l => new {l.UserId, l.LoginProvider, l.Name});
                b.ToTable("Users_Tokens");
            });

            builder.Entity<User>(b =>
            {
                b.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            });

            builder.Entity<Role>(b =>
            {
                b.HasKey(r => r.Id);
                b.HasIndex(r => r.Name).HasName("roles_name_unique").IsUnique();
                b.ToTable("Roles");

                b.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
                b.HasMany<IdentityRoleClaim<string>>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
            });

            builder.Entity<IdentityRoleClaim<string>>(b =>
            {
                b.HasKey(rc => rc.Id);
                b.ToTable("Roles_Claims");
            });

            builder.Entity<UserRole>(b =>
            {
                b.HasKey(r => new {r.UserId, r.RoleId});
                b.HasIndex(r => r.RoleId);
                b.HasIndex(r => r.UserId);

                b.HasOne(r => r.User).WithMany(r => r.UsersRoles).HasForeignKey(r=>r.UserId);
                b.HasOne(r => r.Role).WithMany(r => r.UsersRoles).HasForeignKey(r=>r.RoleId);
            });

            builder.Entity<Client>(b =>
            {
                b.HasIndex(r => r.Name).HasName("clients_name_unique").IsUnique();
                b.HasIndex(r => r.Slug).HasName("clients_slug_unique").IsUnique();
                b.ToTable("Clients");
            });

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

            builder.Entity<Post>(b => { b.Property(r => r.IsPage).HasDefaultValue(false); });

            builder.Entity<PostTag>(b =>
            {
                //b.HasIndex(r => r.Post);
                //b.HasIndex(r => r.Tag);
            });
        }
    }
}