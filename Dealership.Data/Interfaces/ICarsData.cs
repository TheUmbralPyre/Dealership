using Dealership.Data.Models;
using System.Collections.Generic;

namespace Dealership.Data.Interfaces
{
    public interface ICarsData
    {
        Car Get(int Id);
        IEnumerable<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(int id);
    }
}
