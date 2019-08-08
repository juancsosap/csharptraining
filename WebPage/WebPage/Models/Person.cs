using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class Person
    {
        public Int32 Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Person.ModelErrors), ErrorMessageResourceName = "RequiredError")]
        [StringLength(100, MinimumLength = 3, ErrorMessageResourceType = typeof(Resources.Person.ModelErrors), ErrorMessageResourceName = "StringLengthError")]
        [Display(ResourceType = typeof(Resources.Person.Model), Name = "Name")]
        public String Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Person.ModelErrors), ErrorMessageResourceName = "RequiredError")]
        [StringLength(100, MinimumLength = 3, ErrorMessageResourceType = typeof(Resources.Person.ModelErrors), ErrorMessageResourceName = "StringLengthError")]
        [Display(ResourceType = typeof(Resources.Person.Model), Name = "Surname")]
        public String Surname { get; set; }

    }
}