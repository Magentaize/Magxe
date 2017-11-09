﻿using Magxe.Dao.Setting;
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
        public DbSet<IdentityUserRole<string>> UserRoles { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
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

#pragma warning disable CS0618
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
                b.HasMany<IdentityUserRole<string>>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            });

            builder.Entity<IdentityRole>(b =>
            {
                b.HasKey(r => r.Id);
                b.HasIndex(r => r.Name).HasName("roles_name_unique").IsUnique();
                b.ToTable("Roles");

                b.HasMany<IdentityUserRole<string>>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
                b.HasMany<IdentityRoleClaim<string>>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
            });

            builder.Entity<IdentityRoleClaim<string>>(b =>
            {
                b.HasKey(rc => rc.Id);
                b.ToTable("Roles_Claims");
            });

            builder.Entity<IdentityUserRole<string>>(b =>
            {
                b.HasKey(r => new {r.UserId, r.RoleId});
                b.ToTable("Users_Roles");
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

            builder.Entity<PostTag>(b =>
            {
                b.ToTable("Posts_Tags");

                b.HasKey(r => new {r.PostId, r.TagId});
                b.HasIndex(r => r.PostId);
                b.HasIndex(r => r.TagId);

                b.HasOne(r => r.Post).WithMany(r => r.PostTags).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(r => r.Tag).WithMany(r => r.PostTags).OnDelete(DeleteBehavior.Restrict);
            });
#pragma warning restore CS0618
        }
    }
}