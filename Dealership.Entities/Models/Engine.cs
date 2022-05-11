using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dealership.Entities.Models
{
    public enum EngineType
    {
        Diesel,
        Gasoline,
        Electric,
        Hybrid
    }

    public class Engine
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Engine Type")]
        [Required(ErrorMessage = "This Field Is Required!")]
        public EngineType EngineType { get; set; }

        [DisplayFormat(DataFormatString = "{0:F1} Litre")]
        public double Displacement { get; set; }

        [Display(Name = "Horsepower")]
        [DisplayFormat(DataFormatString = "{0} Hp")]
        [Required(ErrorMessage = "This Field Is Required!")]
        public int HorsePower { get; set; }

        [DisplayFormat(DataFormatString = "{0} Kw")]
        [Required(ErrorMessage = "This Field Is Required!")]
        public int Kilowatts { get; set; }

        [Display(Name = "Newton Meters")]
        [DisplayFormat(DataFormatString = "{0} Nm")]
        [Required(ErrorMessage = "This Field Is Required!")]
        public int NewtonMeters { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
