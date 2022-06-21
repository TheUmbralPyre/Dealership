using Dealership.Data.Interfaces;
using Dealership.Data.DataModels;
using Dealership.Data.Services.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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
            carForSale.Title = carForSale.Car.Brand.ToString() + " " + carForSale.Car.ModelName;

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
                .Include(c => c.Car.CarThumbnail)
                .Include(c => c.Car.CarPictures)
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<IEnumerable<CarForSale>> GetAllAsync()
        {
            return await db.CarsForSale
                .Include(c => c.ApplicationUser)
                .Include(c => c.Car)
                .ThenInclude(c => c.Engine)
                .Include(c => c.Car.CarThumbnail)
                .Include(c => c.Car.CarPictures)
                .ToListAsync();
        }

        public async Task UpdateAsync(CarForSale updatedCarForSale)
        {
            // Get the Car For Sale to Update
            var carForSaleToUpdate = await GetAsync(updatedCarForSale.Id);

            // If there is a Difference between the Car Thumbnails...
            if (carForSaleToUpdate.Car.CarThumbnail != updatedCarForSale.Car.CarThumbnail)
            {
                // Get the Old Thumbnail
                var oldThumbnail = db.CarPictureThumbnails.FirstOrDefault(cpt => cpt.Id == carForSaleToUpdate.Car.CarThumbnail.Id);

                // Remove the Old Thumbnail from the Database
                db.Remove(oldThumbnail);

                // Get the New Thumbnail
                updatedCarForSale.Car.CarThumbnail.Car = carForSaleToUpdate.Car;

                // Add the New Thumbnail to the Database
                db.Add(updatedCarForSale.Car.CarThumbnail);
            }

            // If there is a Difference between the Car Pictures...
            if (carForSaleToUpdate.Car.CarPictures != updatedCarForSale.Car.CarPictures)
            {
                // Get the Old Pictures
                var oldPictures = db.CarPictures.Where(cp => cp.CarId == carForSaleToUpdate.Car.Id).ToList();

                // For each Picture in the Old Pictures...
                foreach(var picture in oldPictures)
                {
                    // Remove the Old Picture from the Database
                    db.Remove(picture);
                }

                // For each Picture in the New Pictures...
                foreach (var picture in updatedCarForSale.Car.CarPictures)
                {
                    // Set the Parent of the New Picture to the Car
                    picture.Car = carForSaleToUpdate.Car;

                    // Add the new Picture to the Database
                    db.Add(picture);
                }
            }

            // Assign the Value of the Updated Car for Sale to the Car For Sale to Update
            carForSaleToUpdate = updatedCarForSale;

            // Update the Title of the Car For Sale
            carForSaleToUpdate.Title = carForSaleToUpdate.Car.Brand.ToString() + " " + carForSaleToUpdate.Car.ModelName;

            await db.SaveChangesAsync();
        }
    }
}
