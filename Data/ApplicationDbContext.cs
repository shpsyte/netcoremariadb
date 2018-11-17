using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AppMariaDB.Models;
using Microsoft.AspNetCore.Identity;

namespace AppMariaDB.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("User");
            builder.Entity<ApplicationUser>().HasKey(a => a.Id);
            builder.Entity<IdentityRole>().ToTable("Role");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
            builder.Entity<IdentityUserRole<string>>().HasKey(a => new { a.UserId, a.RoleId });
            builder.Entity<IdentityUserClaim<string>>().HasKey(a => new { a.UserId, a.Id });
            builder.Entity<IdentityUserLogin<string>>().HasKey(a => new { a.UserId, a.ProviderKey });
            builder.Entity<IdentityRoleClaim<string>>().HasKey(a => new { a.RoleId, a.Id });
            builder.Entity<IdentityUserToken<string>>().HasKey(a => new { a.UserId });


        }
    }
}
