using Dealership.Data.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dealership.Data.Interfaces
{
    public interface ICarsData
    {
        Task<Car> GetAsync(int Id);
        Task<IEnumerable<Car>> GetAllAsync();
        Task AddAsync(Car car);
        Task UpdateAsync(Car car);
        Task DeleteAsync(int id);
    }
}
