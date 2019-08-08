using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestedApp.Models
{
    public class AppDBContext : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}
