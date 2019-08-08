using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStarted.Models
{
    public class User
    {
        public Int32 Id { get; set; }

        [Required(ErrorMessage ="{0} is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "{0} length must be between {2} and {1} characters")]
        public String Username { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100)]
        public String Password { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Full Name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required]
        [Range(0, 200, ErrorMessage = "{0} must be between {1} and {2}")]
        public Int32 Age { get; set; }
    }
}