using Dealership.Data.DataModels.IdentityModels;
using Dealership.Data.Services.DatabaseContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Dealership.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            SeedData(host);

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static async void SeedData(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<DealershipDbContext>();
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    // Seed Data
                    await DbContextSeed.SeedRolesAsync(roleManager, context);
                    await DbContextSeed.SeedSuperAdminAsync(userManager, roleManager, context);
                    await DbContextSeed.SeedCarsForSaleAsync(userManager, context);
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
