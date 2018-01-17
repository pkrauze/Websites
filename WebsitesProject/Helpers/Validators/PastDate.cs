using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebsitesProject.Helpers.Validators
{
    public class PastDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int expires = DateTime.Compare((DateTime) value, DateTime.Now);

            return (expires < 0) ? ValidationResult.Success : new ValidationResult("Date cannot be in the future");
        }
    }
}
