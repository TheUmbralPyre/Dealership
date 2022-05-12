using Dealership.Entities.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dealership.Entities.Models
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

        [Display(Name = "Engine Type")]
        [Required(ErrorMessage = "This Field Is Required!")]
        public EngineType EngineType { get; set; }

        [DisplayFormat(DataFormatString = "{0:F1} Litre")]
        [ElectricEngineCannotHaveDisplacement]
        [RequiredDisplacementOnNonElectricEngine("This Field is Required!")]
        [Range(0.1, 12.7, ErrorMessage = "{0} Must be Between {1} and {2}")]
        public double? Displacement { get; set; }

        [Display(Name = "Horsepower")]
        [DisplayFormat(DataFormatString = "{0} Hp")]
        [Required(ErrorMessage = "This Field Is Required!")]
        [Range(1, 1500, ErrorMessage = "{0} Must be Between {1} and {2}")]
        public int Horsepower { get; set; }

        [DisplayFormat(DataFormatString = "{0} Kw")]
        [Required(ErrorMessage = "This Field Is Required!")]
        [Range(1, 1200, ErrorMessage = "{0} Must be Between {1} and {2}")]
        public int Kilowatts { get; set; }

        [Display(Name = "Newton-meters")]
        [DisplayFormat(DataFormatString = "{0} Nm")]
        [Required(ErrorMessage = "This Field Is Required!")]
        [Range(1, 2400, ErrorMessage = "{0} Must be Between {1} and {2}")]
        public int NewtonMeters { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
