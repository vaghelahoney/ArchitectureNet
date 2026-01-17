using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using SuiteRx.Interface.Domain.Entities;
using System.Collections.Generic;

namespace SuiteRx.Interface.Persistance.Contexts
{
    public class PharmacyDBContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IConfiguration _configuration;

        public PharmacyDBContext(DbContextOptions<PharmacyDBContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Registration> Registration { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // required for Identity tables


            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "user123",
                Name = "Admin",
                NormalizedName = "ADMIN"
            });


            // Step 1: Seed User
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "user123",
                    UserName = "googleuser",
                    NormalizedUserName = "GOOGLEUSER",
                    Email = "googleuser@example.com",
                    NormalizedEmail = "GOOGLEUSER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEIkG1u7y5R0Zc7t3npG6sL9uqvTa==",
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    FirstName = "Google",
                    LastName = "User"
                 }
            );


            // Step 2: Then Seed Tokens
            modelBuilder.Entity<IdentityUserToken<string>>().HasData(
                new IdentityUserToken<string>
                {
                    UserId = "user123",
                    LoginProvider = "Google",
                    Name = "AccessToken",
                    Value = "xyz123token"
                }
            );

            modelBuilder.Entity<IdentityUserLogin<string>>().HasData(new IdentityUserLogin<string>
            {
                LoginProvider = "Google",
                ProviderKey = "google-user-id",
                ProviderDisplayName = "Google",
                UserId = "user123"  // ✅ Must match above
            });

            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>
            {
                Id = 1,
                UserId = "user123", // ✅ Must match above
                ClaimType = "Permission",
                ClaimValue = "CanAccessDashboard"
            });

            // Seed Role Claim
            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(new IdentityRoleClaim<string>
            {
                Id = 1,
                RoleId = "user123", // FK to IdentityRole
                ClaimType = "Permission",
                ClaimValue = "CanEdit"
            });

           // Seed User Role(Make sure user with Id "user123" is seeded separately)
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = "user123", // FK to AspNetUsers
                RoleId = "user123"      // FK to IdentityRole
            });




        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}
