using SuiteRx.Interface.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace SuiteRx.Interface.Persistance.Seeders
{
    public static class AspNetUsersSeedData
    {
        // Default passwords for seeding (change these to your desired passwords)
        private const string DefaultPassword = "Admin@123"; // Google User password

        public static List<ApplicationUser> GetUsers()
        {
            return new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = "prakash123",
                    UserName = "vaghela Prakash",
                    NormalizedUserName = "vaghela prakash",
                    Email = "vaghelahoney1@gmail.com",
                    NormalizedEmail = "vaghelahoney1@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = HashPassword(DefaultPassword),
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    FirstName = "vaghela",
                    LastName = "Prakash",
                    DateOfBirth = new DateTime(1990, 1, 1)
                }
            };
        }

        private static string HashPassword(string password)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var user = new ApplicationUser();
            return hasher.HashPassword(user, password);
        }

        /// <summary>
        /// Get seed user credentials for reference
        /// </summary>
        public static List<(string UserName, string Password, string Email)> GetSeedCredentials()
        {
            return new List<(string, string, string)>
            {
                ("adminuser", DefaultPassword, "vaghelahoney1@gmail.com"),
            };
        }
    }
}
