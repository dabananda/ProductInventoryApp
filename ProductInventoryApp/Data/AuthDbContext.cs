using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProductInventoryApp.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Seed roles (Super Admin, Admin, User)
            // Generate a unique id for each role using this command "Console.WriteLine(Guid.NewGuid())" from View->Other Windows->C# Interactive
            var superAdminRoleId = "900824ae-487d-408e-b3bf-4b551dbe559a";
            var adminRoleId = "cf0f75e2-08ab-4a57-a21a-5f8f24b3b826";
            var userRoleId = "f6e72306-861c-46b9-bab5-4d692f0d8e13";

            // Add roles
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = superAdminRoleId,
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN",
                    ConcurrencyStamp = superAdminRoleId,
                },
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = adminRoleId,
                },
                new IdentityRole
                {
                    Id = userRoleId,
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = userRoleId,
                }
            };
            // Add the roles to the model builder
            builder.Entity<IdentityRole>().HasData(roles);

            var superAdminId = "e17b659e-eada-4c9a-8e3a-71551dc7f5a4";
            var superAdminUser = new IdentityUser
            {
                Id = superAdminId,
                UserName = "superadmin",
                Email = "superadmin@email.com",
                NormalizedEmail = "superadmin@email.com".ToUpper(),
                NormalizedUserName = "superadmin".ToUpper(),
            };
            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "Pass@1234");
            builder.Entity<IdentityUser>().HasData(superAdminUser);

            // Add all roles to the super admin
            var supserAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(supserAdminRoles);

            base.OnModelCreating(builder);
        }
    }
}
