using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebSite.Tools.Validators;

namespace WebSite.Models
{
    public class User : IValidatableObject
    {
        public Int32 Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "RequiredError")]
        [StringLength(50, MinimumLength = 8, ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "StringLengthError")]
        [Display(ResourceType = typeof(Resources.User.Model), Name = "Username")]
        public String Username { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "RequiredError")]
        [StringLength(100, MinimumLength = 8, ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "StringLengthError")]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.User.Model), Name = "Password")]
        public String Password { get; set; }

        [NotMapped]
        [Required(ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "RequiredError")]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "CompareError")]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.User.Model), Name = "PasswordValidation")]
        public String PasswordValidation { get; set; }

        [DefaultValue(false)]
        [Display(ResourceType = typeof(Resources.User.Model), Name = "IsActive")]
        public Boolean IsActive { get; set; }

        [Required]
        public Int32 PersonId { get; set; }
        public Person PersonNav { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (!PasswordValidator.IsValid(this, PersonNav))
                errors.Add(new ValidationResult(Resources.ModelErrors.ValueError, new String[] { "Password" }));

            return errors;
        }

    }
}