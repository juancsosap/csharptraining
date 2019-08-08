using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class WebAPIContext : DbContext
    {
        public DbSet<City> Cities { get; set; } 
    }
}