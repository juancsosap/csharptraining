using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestedApp.Models
{
    public class Person : IIndexable
    {
        public int id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required]
        [Range(0, 250)]
        [Display(Name = "Age")]
        public int age { get; set; }

        [Display(Name = "Information")]
        public Dictionary<String, String> info { get; set; }
    }
}