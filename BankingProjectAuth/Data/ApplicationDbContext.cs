using BankingProjectAuth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankingProjectAuth.Data
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
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
            builder.Entity<IdentityRole>().ToTable("Role");
            builder.Entity<ApplicationUser>().ToTable("User");

        }

        public DbSet<Card> Card { get; set; }

        public DbSet<BankingAccount> BankingAccount { get; set; }

        public DbSet<ApplicationUser> User { get; set; }

        public DbSet<IdentityRole> Role { get; set; }

        public DbSet<Credit> Credit { get; set; }

        public DbSet<UtilityBill> UtilityBill { get; set; }

    }
}
