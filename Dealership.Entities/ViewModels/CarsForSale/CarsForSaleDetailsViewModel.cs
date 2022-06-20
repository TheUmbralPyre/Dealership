using Dealership.Entities.Enums.Cars;
using Dealership.Entities.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dealership.Entities.ViewModels.CarsForSale
{
    public class CarsForSaleDetailsViewModel : CarProperties
    {
        public List<CarPictureViewModel> CarPictures { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "${0}")]
        public int Price { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string ProfilePictureCommonPath { get; set; }

    }
}
