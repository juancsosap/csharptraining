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
    public class Person
    {
        public Int32 Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "RequiredError")]
        [System.Web.Mvc.Remote("RutValidator", "People", ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "ValueError")]
        [RutValidator(ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "ValueError")]
        [Display(ResourceType = typeof(Resources.Person.Model), Name = "Rut")]
        public String Rut { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "RequiredError")]
        [StringLength(100, MinimumLength = 3, ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "StringLengthError")]
        [Display(ResourceType = typeof(Resources.Person.Model), Name = "Name")]
        public String Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "RequiredError")]
        [StringLength(100, MinimumLength = 3, ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "StringLengthError")]
        [Display(ResourceType = typeof(Resources.Person.Model), Name = "Surname")]
        public String Surname { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "RequiredError")]
        [Range(0, 200, ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "RangeError")]
        [Display(ResourceType = typeof(Resources.Person.Model), Name = "Age")]
        public Int32 Age { get; set; }

        [Index(IsUnique = true)]
        [Required(ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "RequiredError")]
        [StringLength(200, MinimumLength = 10, ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "StringLengthError")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "FormatError")]
        [Display(ResourceType = typeof(Resources.Person.Model), Name = "Email")]
        public String Email { get; set; }

        [NotMapped]
        [Required(ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "RequiredError")]
        [Compare("Email", ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "CompareError")]
        [Display(ResourceType = typeof(Resources.Person.Model), Name = "EmailValidation")]
        public String EmailValidation { get; set; }

        [RegularExpression("^([+]56)?[1-9][0-9]{8}$", ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "FormatError")]
        [DataType(DataType.PhoneNumber)]
        [Display(ResourceType = typeof(Resources.Person.Model), Name = "Phone")]
        public String Phone { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "RequiredError")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(ResourceType = typeof(Resources.Person.Model), Name = "Inscription")]
        public DateTime Inscription { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "RequiredError")]
        [StringLength(500, MinimumLength = 10, ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "StringLengthError")]
        [DataType(DataType.MultilineText, ErrorMessageResourceType = typeof(Resources.ModelErrors), ErrorMessageResourceName = "FormatError")]
        [Display(ResourceType = typeof(Resources.Person.Model), Name = "Address")]
        public String Address { get; set; }

        // public Int32 UserId { get; set; }

        public User UserNav { get; set; }

    }
}