using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dealership.Data.DataModels
{
    public enum EngineType
    {
        Diesel,
        Gasoline,
        Electric,
        Hybrid,
        Hydrogen
    }

    public class Engine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public EngineType EngineType { get; set; }

        public double? Displacement { get; set; }

        [Required]
        public int Horsepower { get; set; }

        [Required]
        public int Kilowatts { get; set; }

        [Required]
        public int NewtonMeters { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
