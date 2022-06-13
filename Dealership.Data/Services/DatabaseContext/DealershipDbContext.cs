using Dealership.Data.DataModels;
using Dealership.Data.DataModels.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dealership.Data.Services.DatabaseContext
{
    public class DealershipDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        /// <summary>
        /// The Schema Name used for Identity Tables.
        /// </summary>
        private const string identitySchemaName = "Identity";

        public DbSet<Car> Cars { get; set; }

        public DbSet<Engine> Engines { get; set; }

        public DbSet<CarForSale> CarsForSale { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Dealership;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Rename Identity Tables so that they Don't have "AspNet" in their Names
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User", identitySchemaName);
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role", identitySchemaName);
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "UserRoles", identitySchemaName);
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable(name: "UserClaims", identitySchemaName);
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable(name: "UserLogins", identitySchemaName);
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable(name: "RoleClaims", identitySchemaName);
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable(name: "UserTokens", identitySchemaName);
            });
        }
    }
}
