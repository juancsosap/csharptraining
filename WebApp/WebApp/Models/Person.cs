using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Person
    {
        public Int32 PersonID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public String Firstname { get; set; }

        [Required]
        [StringLength(100)]
        public String Surname { get; set; }

        [Required]
        public Int32 Age { get; set; }

        public bool Active { get; set; }

        public DateTime Birthday { get; set; }

        public override bool Equals(object other)
        {
            return this.PersonID == ((Person) other).PersonID;
        }
    }
}