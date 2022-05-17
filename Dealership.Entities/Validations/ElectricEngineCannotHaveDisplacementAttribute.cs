using Dealership.Data.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Dealership.Entities.Validations
{
    public class ElectricEngineCannotHaveDisplacementAttribute : ValidationAttribute, IClientModelValidator
    {
        const string customErrorMessage = "An Electric Engine Cannot Have Displacement, Please Leave the Field Empty!";

        public ElectricEngineCannotHaveDisplacementAttribute()
        {
            ErrorMessage = customErrorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var engine = (Engine)validationContext.ObjectInstance;

            if (engine.EngineType == EngineType.Electric && engine.Displacement != null)
            {
                return new ValidationResult(ErrorMessage);
            }
            else
            {
                return ValidationResult.Success;
            }
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            //context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-electricenginecannothavedisplacement", ErrorMessage);
        }
    }
}
