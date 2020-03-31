using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class Min18YearsAge:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.dateOfBirth == null&&customer.membershipTypeId!=0)
                return new ValidationResult("Date of Birth is required");

            if (customer.membershipTypeId == 1||customer.membershipTypeId == 0)
                  return ValidationResult.Success;
             
            var age = DateTime.Today.Year - customer.dateOfBirth.Value.Year;
            return (age >= 18 ? ValidationResult.Success : new ValidationResult("Customer should be atleast 18 years of age"));

        }
    }
}