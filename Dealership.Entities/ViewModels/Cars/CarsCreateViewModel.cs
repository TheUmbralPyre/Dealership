using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Dealership.Entities.ViewModels.Cars
{
    public class CarsCreateViewModel : CarsCreateAndEditViewModel
    {
        public IEnumerable<IFormFile> Pictures { get; set; }
    }
}
