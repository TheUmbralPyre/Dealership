using Dealership.Data.Enums;
using Dealership.Data.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.Data.Services.DatabaseContext
{
    public static class DbContextSeed
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager,
            DealershipDbContext context)
        {
            // Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));

            context.SaveChanges();
        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, DealershipDbContext context)
        {
            var superAdmin = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "ImperatorOptimum",
                FirstName = "Imperator",
                LastName = "Optimum",
                Email = "imperatorOptimum@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != superAdmin.Id))
            {
                var user = await userManager.FindByEmailAsync(superAdmin.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(superAdmin, "@Ali147852369");
                    await userManager.AddToRoleAsync(superAdmin, Roles.SuperAdmin.ToString());
                    await userManager.AddToRoleAsync(superAdmin, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(superAdmin, Roles.Moderator.ToString());
                    await userManager.AddToRoleAsync(superAdmin, Roles.Basic.ToString());
                }

            }

            context.SaveChanges();
        }
    }
}
