using Dealership.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Dealership.Data.Services.DatabaseContext
{
    public class DealershipDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Dealership;Trusted_Connection=True;");
        }
    }
}
