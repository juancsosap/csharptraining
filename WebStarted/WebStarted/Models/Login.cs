using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStarted.Models
{
    public class Login
    {
        public Int32 LoginID { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "{0} length must be between {2} and {1} characters")]
        public String Username { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "{0} length must be between {2} and {1} characters")]
        public String Password { get; set; }

        [NotMapped]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The Password Validation doesn't match")]
        [DisplayName("Password Validation")]
        public String PasswordValidation { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [CreditCard(ErrorMessage = "{0} invalid")]
        [DisplayName("Credit Card")]
        [StringLength(30, ErrorMessage = "{0} length must as maximum {1} characters")]
        public String CreditCard { get; set; }

        [Remote("__PhoneNumber", "Login", ErrorMessage = "Invalid {0}")]
        [DisplayName("Phone Number")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "{0} length must be between {2} and {1} characters")]
        public String PhoneNumber { get; set; }
    }
}