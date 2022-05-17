using Dealership.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Dealership.Entities.ViewModels.Cars
{
    public class CarsIndexViewModel
    {
        public int Id { get; set; }

        public string ModelName { get; set; }

        public string Generation { get; set; }

        public Transmission Transmission { get; set; }

        public EngineType EngineType { get; set; }

        [DisplayFormat(DataFormatString = "{0:F1} Litre")]
        public double? Displacement { get; set; }

        [DisplayFormat(DataFormatString = "{0} Hp")]
        public int Horsepower { get; set; }

    }
}
