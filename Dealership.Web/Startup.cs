using Dealership.Data.DataModels.IdentityModels;
using Dealership.Data.Models.IdentityModels;
using Dealership.Data.Interfaces;
using Dealership.Data.Services.DatabaseContext;
using Dealership.Data.Services.ImageServices;
using Dealership.Data.Services.SQLServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Dealership.Data.DataModels;
using Mapster;
using MapsterMapper;
using System.Reflection;
using Dealership.Data.Interfaces.PictureInterfaces;

namespace Dealership.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISQLData<CarForSale>, SQLCarsForSaleData>();
            services.AddDbContext<DealershipDbContext>();

            // Inject Profile Picture Service
            services.AddTransient<IProfilePictureService, ProfilePictureService>();
            // Inject Car Picture Service
            services.AddTransient<ICarPicturesService, CarPictureService>();

            // Create a new Configuration for Mapster
            var config = new TypeAdapterConfig();
            // Scan for Mappings in the Entities Project
            config.Scan(Assembly.Load("Dealership.Entities"));
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            // Inject Identity
            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DealershipDbContext>();
            
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Cars/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // User Authentication Middleware
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "AreaCarsForSale",
                    areaName: "CarsForSale",
                    pattern: "{area:exists}/{controller=CarsForSale}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=CarsForSale}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
