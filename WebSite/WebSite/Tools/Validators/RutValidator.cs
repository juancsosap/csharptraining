using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebSite.Tools.Validators
{
    public class RutValidator
    {
        public static bool IsValid(String Rut)
        {
            if (isRut(Rut))
            {
                String RutClean = Rut.Replace(".", "");
                RutClean = RutClean.Substring(0, RutClean.Length - 2);
                String VDigit = Rut.Substring(Rut.Length - 1);

                return VerificationDigit(RutClean).Equals(VDigit);
            }
            
            return false;
        }

        private static String VerificationDigit(String rut)
        {
            int[] serie = new int[] { 2, 3, 4, 5, 6, 7 };
            int result = 0;
            for (int i = rut.Length - 1; i >= 0; i--)
            {
                int digit = Int32.Parse(rut.Substring(i, 1));
                int index = (rut.Length - 1 - i) % 6;
                result += digit * serie[index];
            }
            result = 11 - (result % 11);
            if (result == 11) { return "0"; }
            else if (result == 10) { return "k"; }
            else { return result + ""; }
        }

        private static bool isRut(String rut)
        {
            Regex regex = new Regex("^[1-9][0-9]?([.]?[0-9]{3}){2}[-][0-9k]$");
            return regex.IsMatch(rut);
        }
    }

    public class RutValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                String Rut = (String) value;
                ValidationResult ValidationFail = new ValidationResult(FormatErrorMessage(validationContext.DisplayName));

                return RutValidator.IsValid(Rut) ? ValidationResult.Success : ValidationFail;
            }

            return ValidationResult.Success;
        }
    }
}