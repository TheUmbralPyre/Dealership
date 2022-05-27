using Dealership.Entities.ViewModels.Cars;
using Dealership.Entities.Enums.Cars;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Dealership.Entities.Validations
{
    public class RequiredDisplacementOnNonElectricEngineAttribute : ValidationAttribute, IClientModelValidator
    {
        public RequiredDisplacementOnNonElectricEngineAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var engine = (CarsCreateAndEditViewModel)validationContext.ObjectInstance;

            if ( (engine.EngineType == EngineType.Electric && value == null)
                || (engine.EngineType != EngineType.Electric && value != null))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-requireddisplacementonnonelectricengine", ErrorMessage);
        }
    }
}
