using Dealership.Entities.Enums.Cars;
using Dealership.Entities.Validations;
using System.ComponentModel.DataAnnotations;

namespace Dealership.Entities.ViewModels.Cars
{
    public class CarsIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "This Field Is Required!")]
        [MaxLength(50, ErrorMessage = "Cannot be Longer than 50 Characters!")]
        public string ModelName { get; set; }

        [Required(ErrorMessage = "This Field Is Required!")]
        [MaxLength(50, ErrorMessage = "Cannot be Longer than 50 Characters!")]
        public string Generation { get; set; }

        [Required(ErrorMessage = "This Field Is Required!")]
        public Transmission Transmission { get; set; }

        [Display(Name = "Engine Type")]
        [Required(ErrorMessage = "This Field Is Required!")]
        public EngineType EngineType { get; set; }

        [DisplayFormat(DataFormatString = "{0:F1} Litre")]
        [ElectricEngineCannotHaveDisplacement]
        [RequiredDisplacementOnNonElectricEngine("This Field is Required!")]
        [Range(0.1, 12.7, ErrorMessage = "{0} Must be Between {1} and {2}")]
        public double? Displacement { get; set; }

        [DisplayFormat(DataFormatString = "{0} Hp")]
        [Required(ErrorMessage = "This Field Is Required!")]
        [Range(1, 1500, ErrorMessage = "{0} Must be Between {1} and {2}")]
        public int Horsepower { get; set; }

        public string UserName { get; set; }
    }
}
