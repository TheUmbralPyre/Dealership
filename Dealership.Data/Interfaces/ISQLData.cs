using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dealership.Data.Interfaces
{
    public interface ISQLData<T>
    {
        Task<T> GetAsync(int Id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
