using Dealership.Data.Enums;
using Dealership.Data.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Dealership.Data.Services.DatabaseContext
{
    public static class DbContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager
            , RoleManager<IdentityRole> roleManager, DealershipDbContext context)
        {
            // Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));

            context.SaveChanges();
        }
    }
}
