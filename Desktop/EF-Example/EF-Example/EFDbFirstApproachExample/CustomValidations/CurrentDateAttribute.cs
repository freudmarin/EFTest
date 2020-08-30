using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFDbFirstApproachExample.CustomValidations
{
    public class CurrentDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            if (dateTime <= DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else return new ValidationResult(this.ErrorMessage);
        }
    }
}