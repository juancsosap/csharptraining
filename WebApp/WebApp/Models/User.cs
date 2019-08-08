using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class User
    {
        public Int32 UserID { get; set; }

        [Required]
        public String Username { get; set; }

        [Required]
        public String Password { get; set; }

        public UserStatus Status { get; set; }

        public Int32 PersonID { get; set; }

        public override bool Equals(object other)
        {
            return this.UserID == ((User) other).UserID;
        }
    }
}