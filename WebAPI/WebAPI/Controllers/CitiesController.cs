using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class CitiesController : ApiController
    {
        WebAPIContext db = new WebAPIContext();

        public IEnumerable<City> Get()
        {
            return db.Cities.ToList();
        }

        public City Get(Int32 id)
        {
            return db.Cities.Find(id);
        }

        public void Post([FromBody]City value)
        {
            db.Cities.Add(value);
            db.SaveChanges();
        }

        public void Put(int id, [FromBody]City value)
        {
            City city = db.Cities.Where(c => c.CityID == id).SingleOrDefault();
            city.Name = value.Name;
            city.CountryCode = value.CountryCode;
            city.District = value.District;
            city.Population = value.Population;

            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Cities.Remove(new City() { CityID = id });
            db.SaveChanges();
        }

    }
}
