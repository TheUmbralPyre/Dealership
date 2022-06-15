using Dealership.Data.Enums;
using Dealership.Data.DataModels.IdentityModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Dealership.Data.DataModels;

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

        public static async Task SeedCarsForSaleAsync(UserManager<ApplicationUser> userManager, DealershipDbContext context)
        {
            // Seed Car For Sale Golf
            // Create Golf Seller
            var karlJones = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "KJones",
                FirstName = "Karl",
                LastName = "Jones",
                Email = "kjones@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            // Create Car Golf
            var golf = new Car
            {
                ModelName = "Golf",
                Generation = "4",
                BodyType = BodyType.Hatchback,
                Year = 2002,
                Color = "Black",
                Mileage = 1000000,
                Transmission = Transmission.Manual,
                Engine = new Engine
                {
                    EngineType = EngineType.Diesel,
                    Displacement = 1.9,
                    Horsepower = 130,
                    Kilowatts = 93,
                    NewtonMeters = 310
                }
            };

            // Create Car For Sale
            var golfForSale = new CarForSale
            {
                ApplicationUser = karlJones,
                Car = golf,
                DateAdded = DateTime.Now
            };

            // Seed Golf Seller and Car For Sale
            if (userManager.Users.All(u => u.Id != karlJones.Id))
            {
                var user = await userManager.FindByEmailAsync(karlJones.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(karlJones, "@Ali147852369");
                    await userManager.AddToRoleAsync(karlJones, Roles.Basic.ToString());

                    context.Add(golfForSale.Car.Engine);
                    context.Add(golfForSale.Car);
                    context.Add(golfForSale);
                }

            }


            // Seed Car For Sale Mercedes
            // Create Mercedes Seller
            var adamBens = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "a(d)bs",
                FirstName = "Adam",
                LastName = "Bens",
                Email = "benser@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            // Create Car Mercedes
            var cClass = new Car
            {
                ModelName = "C-Class",
                Generation = "W205",
                BodyType = BodyType.Sedan,
                Year = 2016,
                Color = "Silver",
                Mileage = 1000,
                Transmission = Transmission.CVT,
                Engine = new Engine
                {
                    EngineType = EngineType.Diesel,
                    Displacement = 2.0,
                    Horsepower = 181,
                    Kilowatts = 135,
                    NewtonMeters = 300
                }
            };

            // Create Car For Sale
            var cClassForSale = new CarForSale
            {
                ApplicationUser = adamBens,
                Car = cClass,
                DateAdded = DateTime.Now
            };

            // Seed Mercedes Seller and Car For Sale
            if (userManager.Users.All(u => u.Id != adamBens.Id))
            {
                var user = await userManager.FindByEmailAsync(adamBens.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(adamBens, "@Ali147852369");
                    await userManager.AddToRoleAsync(adamBens, Roles.Basic.ToString());

                    context.Add(cClassForSale.Car.Engine);
                    context.Add(cClassForSale.Car);
                    context.Add(cClassForSale);
                }

            }


            // Seed Car For Sale Mustang
            // Create Mustang Seller
            var JaySevenfold = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Avenged",
                FirstName = "Jay",
                LastName = "Sevenfold",
                Email = "TheManHanged@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            // Create Car Mustang
            var mustang = new Car
            {
                ModelName = "Mustang",
                Generation = "Ecoboost",
                BodyType = BodyType.Coupe,
                Year = 2019,
                Color = "Crimson",
                Mileage = 9000,
                Transmission = Transmission.Manual,
                Engine = new Engine
                {
                    EngineType = EngineType.Gasoline,
                    Displacement = 2.3,
                    Horsepower = 310,
                    Kilowatts = 228,
                    NewtonMeters = 476
                }
            };

            // Create Car For Sale
            var mustangForSale = new CarForSale
            {
                ApplicationUser = JaySevenfold,
                Car = mustang,
                DateAdded = DateTime.Now
            };

            // Seed Mustang Seller and Car For Sale
            if (userManager.Users.All(u => u.Id != JaySevenfold.Id))
            {
                var user = await userManager.FindByEmailAsync(JaySevenfold.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(JaySevenfold, "@Ali147852369");
                    await userManager.AddToRoleAsync(JaySevenfold, Roles.Basic.ToString());

                    context.Add(mustangForSale.Car.Engine);
                    context.Add(mustangForSale.Car);
                    context.Add(mustangForSale);
                }

            }

            context.SaveChanges();
        }
    }
}
