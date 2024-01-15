using PersonalInfomrationProject.Helpers.Validators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PersonalInfomrationProject.ValidationRules
{
    public class RequiredValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string s)
            {
                if (string.IsNullOrEmpty(s))
                {
                    return new ValidationResult(false, "Please enter a value");
                }
                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "Invalid input");
        }
    }

    public class EmailValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string val)
            {
                if (string.IsNullOrEmpty(val))
                {
                    return new ValidationResult(false, "Please enter email address");
                }
                if (!val.IsValidEmailAddress())
                {
                    return new ValidationResult(false, "Email address is not valid");
                }
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Invalid input");
        }
    }
    public class UsPhoneValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string val)
            {
                if (string.IsNullOrEmpty(val))
                {
                    return new ValidationResult(false, "Please enter phone number with US format i.e. (123) 456-7890");
                }
                if (!val.IsValidUsNumber())
                {
                    return new ValidationResult(false, "Phone number  is not valid");
                }
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Invalid input");
        }
    }

    public class AgeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is DateTime val)
            {
                if (val.isAgeLessThan18())
                {
                    return new ValidationResult(false, "Age is less than 18");
                }
                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "Invalid input");
        }
    }
}
