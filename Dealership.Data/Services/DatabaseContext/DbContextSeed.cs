using Dealership.Data.Enums;
using Dealership.Data.DataModels.IdentityModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Dealership.Data.DataModels;
using Dealership.Data.DataModels.CarModels;
using System.IO;
using System.Collections.Generic;

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
        /// /AREAS AND PERMISSIONS
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
                PhoneNumber = "0876323609",
                PhoneNumberConfirmed = true,
                ProfilePictureOriginalPath = "profile-pictures\\seed\\ImperatorOptimum_Original.jpeg",
                ProfilePictureManagePath = "profile-pictures\\seed\\ImperatorOptimum_Manage.jpeg",
                ProfilePictureNavbarPath = "profile-pictures\\seed\\ImperatorOptimum_Navbar.jpeg",
                ProfilePictureCommonPath = "profile-pictures\\seed\\ImperatorOptimum_Common.jpeg"
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
            // Seed Car For Sale Supra
            // Create Supra Seller
            var karlJones = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "KJones",
                FirstName = "Karl",
                LastName = "Jones",
                Email = "kjones@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "0879432375",
                PhoneNumberConfirmed = true,
                ProfilePictureOriginalPath = "profile-pictures\\seed\\Default_Original.jpeg",
                ProfilePictureManagePath = "profile-pictures\\seed\\Default_Manage.jpeg",
                ProfilePictureNavbarPath = "profile-pictures\\seed\\Default_Navbar.jpeg",
                ProfilePictureCommonPath = "profile-pictures\\seed\\Default_Common.jpeg"
            };

            // Create Car Supra
            var supra = new Car
            {
                Brand = Brand.Toyota,
                ModelName = "Supra",
                BodyType = BodyType.Coupe,
                Year = 1994,
                Color = "Black",
                Mileage = 52500,
                Transmission = Transmission.Manual,
                Engine = new Engine
                {
                    EngineType = EngineType.Gasoline,
                    Displacement = 3.0,
                    Horsepower = 600,
                    Kilowatts = 540,
                    NewtonMeters = 400
                },
                CarThumbnail = new CarPictureThumbnail() { Path = "car-thumbnails/seed/4d903346-3fb6-49ad-ab91-bf9f037f98fa.jpeg" },
                CarPictures = new List<CarPicture>()
                {
                    new CarPicture 
                    { 
                        OriginalPath = "car-pictures/seed/0579e3c8-93b9-4149-a571-b1e5d6f20e7f_Original.jpeg",
                        SlidePath = "car-pictures/seed/0579e3c8-93b9-4149-a571-b1e5d6f20e7f_Slide.jpeg"
                    },
                    new CarPicture
                    {
                        OriginalPath = "car-pictures/seed/651264b6-da31-44d8-911e-8613a01845d9_Original.jpeg",
                        SlidePath = "car-pictures/seed/651264b6-da31-44d8-911e-8613a01845d9_Slide.jpeg"
                    },
                    new CarPicture
                    {
                        OriginalPath = "car-pictures/seed/933681c6-94d4-4132-a490-0be8cb7f0b1c_Original.jpeg",
                        SlidePath = "car-pictures/seed/933681c6-94d4-4132-a490-0be8cb7f0b1c_Slide.jpeg"
                    }
                }
            };

            // Create Car For Sale
            var supraForSale = new CarForSale
            {
                ApplicationUser = karlJones,
                Car = supra,
                DateAdded = DateTime.Now,
                Description = "THIS... is a 1994 Toyota Supra SZ, finished in black with a black interior. This is a right-hand-drive, Japanese-spec car titled in Nebraska. It's equipped with a metric instrument cluster and its odometer displays about 84,500 kilometers, which represents around 52,500 miles. The list of modifications reported by the seller includes a CXRacing turbocharger kit, a Mishimoto radiator, DeatschWerks 700cc fuel injectors, aftermarket parts in the exhaust system, HSD coilovers, a GReddy GRacer front splitter, and a Kenwood touchscreen. More details about the aftermarket parts installed on this Supra are provided below, and some of the removed factory parts are included in the sale. Launched in Japan in 1993, the fourth-generation Supra (called \"A80\" internally) was celebrated as one of Toyota's best sports cars even before it earned a starring role in the Fast & Furious franchise. It offered performance that rivaled much more expensive cars and the reliability expected from a Toyota. Production ended in 2002, and the nameplate was consigned to the automotive attic until the BMW-based model arrived in 2019. Power comes from a 3.0-liter turbocharged straight-6, rated at about 225 horsepower and 210 lb-ft of torque when left stock and naturally-aspirated. The modifications likely increase those figures, but a dyno sheet is not available. Called \"2JZ - GE\" internally, the engine spins the rear wheels via a 5-speed manual transmission.",
                Price = 30000,
                Title = supra.Brand.ToString() + " " + supra.ModelName
            };

            // Seed Supra Seller and Car For Sale
            if (userManager.Users.All(u => u.Id != karlJones.Id))
            {
                var user = await userManager.FindByEmailAsync(karlJones.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(karlJones, "@Ali147852369");
                    await userManager.AddToRoleAsync(karlJones, Roles.Basic.ToString());

                    context.Add(supraForSale);
                }

            }


            // Seed Car For Sale M3
            // Create M3 Seller
            var adamBens = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "adbs",
                FirstName = "Adam",
                LastName = "Bens",
                Email = "benser@gmail.com",
                PhoneNumber = "0879487321",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ProfilePictureOriginalPath = "profile-pictures\\seed\\Default_Original.jpeg",
                ProfilePictureManagePath = "profile-pictures\\seed\\Default_Manage.jpeg",
                ProfilePictureNavbarPath = "profile-pictures\\seed\\Default_Navbar.jpeg",
                ProfilePictureCommonPath = "profile-pictures\\seed\\Default_Common.jpeg"
            };

            // Create Car M3
            var mThree = new Car
            {
                Brand = Brand.BMW,
                ModelName = "M3",
                BodyType = BodyType.Coupe,
                Year = 2009,
                Color = "Jet Black",
                Mileage = 1364000,
                Transmission = Transmission.Automatic,
                Engine = new Engine
                {
                    EngineType = EngineType.Diesel,
                    Displacement = 4.0,
                    Horsepower = 414,
                    Kilowatts = 360,
                    NewtonMeters = 600
                },
                CarThumbnail = new CarPictureThumbnail() { Path = "car-thumbnails/seed/eef062b5-7e3c-47f9-a91a-3a58cb99cefb.jpeg" },
                CarPictures = new List<CarPicture>()
                {
                    new CarPicture
                    {
                        OriginalPath = "car-pictures/seed/81638de9-03dc-494b-bd55-d8b2bd33c976_Original.jpeg",
                        SlidePath = "car-pictures/seed/81638de9-03dc-494b-bd55-d8b2bd33c976_Slide.jpeg"
                    },
                    new CarPicture
                    {
                        OriginalPath = "car-pictures/seed/96a07506-7808-4f97-a327-5b3811d0de7e_Original.jpeg",
                        SlidePath = "car-pictures/seed/96a07506-7808-4f97-a327-5b3811d0de7e_Slide.jpeg"
                    },
                    new CarPicture
                    {
                        OriginalPath = "car-pictures/seed/e490c7a2-b97c-42eb-9d45-690b11495659_Original.jpeg",
                        SlidePath = "car-pictures/seed/e490c7a2-b97c-42eb-9d45-690b11495659_Slide.jpeg"
                    }
                }
            };

            // Create Car For Sale
            var mThreeCarForSale = new CarForSale
            {
                ApplicationUser = adamBens,
                Car = mThree,
                DateAdded = DateTime.Now,
                Description = "THIS... is a 2009 BMW M3, finished in Jet Black with a black interior. The attached Carfax vehicle history shows that this M3 has been registered Florida, Texas, and California since new. A build sheet is shown in the gallery, and a partial list of notable equipment includes the Premium Package (power folding mirrors, Universal Garage Door Opener, aluminum interior trim, digital compass mirror, BMW Assist), 18-inch Style 219M wheels, a power sunroof, Novillo leather upholstery, power-adjustable front seats, dual-zone automatic climate control, and a CD player. Modifications reported by the seller are limited to tinted windows and tinted front side reflectors. BMW engineers had to balance horsepower and weight as they developed the first and only M3 equipped with a V8 engine. Released for 2008, and based on the E90-generation 3 Series, it won over skeptical enthusiasts by offering performance that approached supercar levels in a practical, daily-drivable, and relatively subtle package. Sedan, coupe, and convertible variants were offered. Power comes from a 4.0-liter \"S65\" V8, rated at 414 horsepower and 295 lb-ft of torque. Output is sent to the rear wheels via a 7-speed automatic transmission.",
                Price = 9000,
                Title = mThree.Brand.ToString() + " " + mThree.ModelName
            };

            // Seed M3 Seller and Car For Sale
            if (userManager.Users.All(u => u.Id != adamBens.Id))
            {
                var user = await userManager.FindByEmailAsync(adamBens.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(adamBens, "@Ali147852369");
                    await userManager.AddToRoleAsync(adamBens, Roles.Basic.ToString());

                    context.Add(mThreeCarForSale);
                }

            }

            context.SaveChanges();
        }
    }
}
