using Dealership.Data.Interfaces;
using Dealership.Data.Models;
using Dealership.Data.Services.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dealership.Data.Services.SQLServices
{
    public class SQLCarsData : ICarsData
    {
        protected readonly DealershipDbContext db;

        public SQLCarsData(DealershipDbContext db)
        {
            this.db = db;
        }

        public async Task AddAsync(Car car)
        {
            db.Add(car.Engine);
            db.Add(car);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var carToDelete = await db.Cars
                .Include(e => e.Engine)
                .FirstOrDefaultAsync(c => c.Id == Id);
            db.Cars.Remove(carToDelete);
            await db.SaveChangesAsync();
        }

        public async Task<Car> GetAsync(int Id)
        {
            return await db.Cars
                .Include(e => e.Engine)
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await db.Cars.Include(e => e.Engine).ToListAsync();
        }

        public async Task UpdateAsync(Car carToUpdate)
        {
            db.Cars.Update(carToUpdate);
            await db.SaveChangesAsync();
        }
    }
}
