using Dealership.Entities.Enums.Cars;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dealership.Entities.ViewModels.CarsForSale
{
    public class CarsForSaleDeleteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Model")]
        public string ModelName { get; set; }

        public Brand Brand { get; set; }

        public List<CarPictureViewModel> CarPictures { get; set; }

    }
}
