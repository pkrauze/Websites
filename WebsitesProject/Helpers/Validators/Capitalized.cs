using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebsitesProject.Helpers.Validators
{
    public class Capitalized : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return char.IsUpper(value.ToString().First()) ? 
                ValidationResult.Success 
                : new ValidationResult(validationContext.DisplayName + " should start with capital letter.");
        }
    }
}
