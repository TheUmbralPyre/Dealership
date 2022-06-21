using Dealership.Entities.AbstractClasses.CarsForSale;
using System.Collections.Generic;

namespace Dealership.Entities.ViewModels.CarsForSale
{
    public class CarsForSaleDetailsViewModel : CarForSaleProperties
    {
        public int Id { get; set; }

        public List<CarPictureViewModel> CarPictures { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string ProfilePictureCommonPath { get; set; }

        public string SellerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
