using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pagina.Models
{
    public class AppDBContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
    }
}