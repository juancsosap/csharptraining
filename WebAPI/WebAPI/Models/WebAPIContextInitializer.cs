using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class WebAPIContextInitializer : DropCreateDatabaseAlways<WebAPIContext>
    {
        protected override void Seed(WebAPIContext db)
        {
            db.Cities.Add(new City()
            {
                Name = "Santiago",
                CountryCode = "CHL",
                District = "Santiago Centro",
                Population = 10_000_000
            });

            db.SaveChanges();
        }
    }
}