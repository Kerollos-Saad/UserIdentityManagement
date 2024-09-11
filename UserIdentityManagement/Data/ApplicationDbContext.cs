using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserIdentityManagement.Models;

namespace UserIdentityManagement.Data
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

            builder.Entity<ApplicationUser>()
                .ToTable("Users", "security");
            builder.Entity<IdentityRole>()
                .ToTable("Roles", "security");
            builder.Entity<IdentityUserRole<String>>()
                .ToTable("UserRoles", "security");
            builder.Entity<IdentityUserClaim<String>>()
                .ToTable("UserClaims", "security");
            builder.Entity<IdentityUserLogin<String>>()
                .ToTable("UserLogins", "security");
            builder.Entity<IdentityRoleClaim<String>>()
                .ToTable("RoleClaims", "security");
            builder.Entity<IdentityUserToken<String>>()
                .ToTable("UserTokens", "security");
        }
    }
}
