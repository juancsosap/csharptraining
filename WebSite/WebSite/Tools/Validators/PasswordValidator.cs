using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Models;

namespace WebSite.Tools.Validators
{
    public class PasswordValidator
    {
        public static bool IsValid(User user, Person person)
        {
            List<String> list = new List<String>();

            //list.AddRange(person.Name.Split(' '));
            //list.AddRange(person.Surname.Split(' '));
            
            foreach (String value in list)
            {
                if (user.Password.Contains(value))
                    return false;
            }
            return true;
        }
    }
}