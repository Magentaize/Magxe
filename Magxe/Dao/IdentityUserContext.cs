using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Dao
{
    public class IdentityUserContext<TUser, TKey, TUserClaim, TUserLogin, TUserToken> : Microsoft.EntityFrameworkCore.DbContext
        where TUser : IdentityUser<TKey>
        where TKey : IEquatable<TKey>
        where TUserClaim : IdentityUserClaim<TKey>
        where TUserLogin : IdentityUserLogin<TKey>
        where TUserToken : IdentityUserToken<TKey>
    {
        public IdentityUserContext(DbContextOptions options) : base(options)
        {
        }

        protected IdentityUserContext()
        {
        }

        public DbSet<TUser> Users { get; set; }

        public DbSet<TUserClaim> UserClaims { get; set; }

        public DbSet<TUserLogin> UserLogins { get; set; }

        public DbSet<TUserToken> UserTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TUser>(b =>
            {
                b.HasKey(u => u.Id);
                b.HasIndex(u => u.Slug).HasName("users_slug_unique").IsUnique();
                b.HasIndex(u => u.Email).HasName("users_email_unique").IsUnique();
                b.ToTable("Users");

                // Replace with b.HasMany<IdentityUserClaim>().
                b.HasMany<TUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
                b.HasMany<TUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
                b.HasMany<TUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
            });

            builder.Entity<TUserClaim>(b =>
            {
                b.HasKey(uc => uc.Id);
                b.ToTable("Users_Claims");
            });

            builder.Entity<TUserLogin>(b =>
            {
                b.HasKey(l => new {l.LoginProvider, l.ProviderKey});
                b.ToTable("Users_Logins");
            });

            builder.Entity<TUserToken>(b =>
            {
                b.HasKey(l => new {l.UserId, l.LoginProvider, l.Name});
                b.ToTable("Users_Tokens");
            });
        }
    }
}