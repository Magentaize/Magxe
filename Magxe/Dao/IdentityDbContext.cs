using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Magxe.Dao
{
    public class IdentityDbContext<TUser, TRole, TKey> : IdentityDbContext<TUser, TRole, TKey, IdentityUserClaim<TKey>,
        IdentityUserRole<TKey>, IdentityUserLogin<TKey>, IdentityRoleClaim<TKey>, IdentityUserToken<TKey>>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
    {
        public IdentityDbContext(DbContextOptions options) : base(options)
        {
        }

        protected IdentityDbContext()
        {
        }
    }

    public class
        IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken> :
            IdentityUserContext<TUser, TKey, TUserClaim, TUserLogin, TUserToken>
        where TUser : IdentityUser<TKey>
        where TKey : IEquatable<TKey>
        where TRole : IdentityRole<TKey>
        where TUserClaim : IdentityUserClaim<TKey>
        where TUserRole : IdentityUserRole<TKey>
        where TRoleClaim : IdentityRoleClaim<TKey>
        where TUserLogin : IdentityUserLogin<TKey>
        where TUserToken : IdentityUserToken<TKey>
    {
        public IdentityDbContext(DbContextOptions options) : base(options)
        {
        }

        protected IdentityDbContext()
        {
        }

        public DbSet<TUserRole> UserRoles { get; set; }

        public DbSet<TRole> Roles { get; set; }

        public DbSet<TRoleClaim> RoleClaims { get; set; }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TUser>(b =>
            {
                b.HasMany<TUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            });

            builder.Entity<TRole>(b =>
            {
                b.HasKey(r => r.Id);
                b.HasIndex(r => r.Name).HasName("roles_name_unique").IsUnique();
                b.ToTable("Roles");

                b.HasMany<TUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
                b.HasMany<TRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
            });

            builder.Entity<TRoleClaim>(b =>
            {
                b.HasKey(rc => rc.Id);
                b.ToTable("Roles_Claims");
            });

            builder.Entity<TUserRole>(b =>
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
        }
    }
}