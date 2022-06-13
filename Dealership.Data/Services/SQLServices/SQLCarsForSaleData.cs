using Dealership.Data.Interfaces;
using Dealership.Data.DataModels;
using Dealership.Data.Services.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dealership.Data.Services.SQLServices
{
    public class SQLCarsForSaleData : ISQLData<CarForSale>
    {
        protected readonly DealershipDbContext db;

        public SQLCarsForSaleData(DealershipDbContext db)
        {
            this.db = db;
        }

        public async Task AddAsync(CarForSale carForSale)
        {
            db.Add(carForSale.Car.Engine);
            db.Add(carForSale.Car);
            db.Add(carForSale);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var carToDelete = await db.CarsForSale
                .Include(c => c.Car)
                .Include(e => e.Car.Engine)
                .FirstOrDefaultAsync(c => c.Id == Id);
            db.CarsForSale.Remove(carToDelete);
            await db.SaveChangesAsync();
        }

        public async Task<CarForSale> GetAsync(int Id)
        {
            return await db.CarsForSale
                .Include(c => c.ApplicationUser)
                .Include(c => c.Car)
                .ThenInclude(c => c.Engine)
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<IEnumerable<CarForSale>> GetAllAsync()
        {
            return await db.CarsForSale
                .Include(c => c.ApplicationUser)
                .Include(c => c.Car)
                .ThenInclude(c => c.Engine)
                .ToListAsync();
        }

        public async Task UpdateAsync(CarForSale carToUpdate)
        {
            db.CarsForSale.Update(carToUpdate);
            db.Cars.Update(carToUpdate.Car);
            db.Engines.Update(carToUpdate.Car.Engine);

            await db.SaveChangesAsync();
        }
    }
}
