using Dealership.Entities.Enums.Cars;
using System.ComponentModel.DataAnnotations;

namespace Dealership.Entities.ViewModels.Cars
{
    public class CarsIndexViewModel
    {
        public int Id { get; set; }

        public Brand Brand { get; set; }

        [Display(Name = "Model")]

        public string ModelName { get; set; }

        public Transmission Transmission { get; set; }

        [Display(Name = "Engine Type")]
        public EngineType EngineType { get; set; }

        [DisplayFormat(DataFormatString = "{0:F1} Litre")]
        public double? Displacement { get; set; }

        [DisplayFormat(DataFormatString = "{0} Hp")]
        public int Horsepower { get; set; }

        public string UserName { get; set; }

        public string ThumbnailPath { get; set; }

        [DisplayFormat(DataFormatString = "{0}$")]
        public int Price { get; set; }
    }
}
