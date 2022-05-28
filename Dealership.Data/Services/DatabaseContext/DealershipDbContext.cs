using Dealership.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dealership.Data.Services.DatabaseContext
{
    public class DealershipDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Engine> Engines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Dealership;Trusted_Connection=True;");
        }
    }
}
