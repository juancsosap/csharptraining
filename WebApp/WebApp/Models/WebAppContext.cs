using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class WebAppContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<User> Users { get; set; }
    }
}