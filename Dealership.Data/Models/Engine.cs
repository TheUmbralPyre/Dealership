using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dealership.Data.Models
{
    public enum EngineType
    {
        Diesel,
        Gasoline,
        Electrict,
        Hybrid
    }

    public class Engine
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This Field Is Required!")]
        public EngineType EngineType { get; set; }

        public double Displacement { get; set; }

        [Required(ErrorMessage = "This Field Is Required!")]
        public int HorsePower { get; set; }
        [Required(ErrorMessage = "This Field Is Required!")]
        public int Kilowatts { get; set; }
        [Required(ErrorMessage = "This Field Is Required!")]
        public int NewtonMeters { get; set; }
    }
}
