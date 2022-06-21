using System.ComponentModel.DataAnnotations;

namespace Dealership.Entities.ViewModels.CarsForSale
{
    public class CarsForSaleEditViewModel : CarForSaleProperties
    {
        public int Id { get; set; }
    }
}
