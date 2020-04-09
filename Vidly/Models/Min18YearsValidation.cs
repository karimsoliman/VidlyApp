using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Enums;

namespace Vidly.Models
{
    public class Min18YearsValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MemberShipTypeId == (int)MemberShipTypeEnum.Unknown || customer.MemberShipTypeId == (int)MemberShipTypeEnum.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is Required.");
            }

            var years = DateTime.Now.Year - customer.Birthdate.Value.Year;

            return (years >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be at least 18 years to go on a membership."); 
        }
    }
}