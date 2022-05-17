using Dealership.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Dealership.Entities.ViewModels.Cars
{
    public class CarsCreateViewModel
    {
        [Required]
        public string ModelName { get; set; }

        public string Generation { get; set; }
        public int Year { get; set; }

        public BodyType BodyType { get; set; }

        public string Color { get; set; }

        public Transmission Transmission { get; set; }

        public int Mileage { get; set; }

        public Status Status { get; set; }

        public EngineType EngineType { get; set; }

        public double? Displacement { get; set; }

        public int Horsepower { get; set; }

        public int Kilowatts { get; set; }

        public int NewtonMeters { get; set; }
    }
}
