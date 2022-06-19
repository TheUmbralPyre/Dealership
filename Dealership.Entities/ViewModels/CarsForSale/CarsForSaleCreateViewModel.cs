using System.ComponentModel.DataAnnotations;

namespace Dealership.Entities.ViewModels.CarsForSale
{
    public class CarsForSaleCreateViewModel : CarProperties
    {
        public string Uploads { get; set; }


        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        [Range(1, 1000000)]
        public int Price { get; set; }
    }
}
