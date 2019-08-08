using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class City
    {
        public Int32 CityID { get; set; }

        public String Name { get; set; }

        public String CountryCode { get; set; }

        public String District { get; set; }
        
        public Int32 Population { get; set; }
    }
}