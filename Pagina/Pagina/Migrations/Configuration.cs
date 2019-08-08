namespace Pagina.Migrations
{
    using Pagina.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Pagina.Models.AppDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Pagina.Models.AppDBContext";
        }

        protected override void Seed(AppDBContext db)
        {
            /*
             * db.Personas.AddOrUpdate(new Persona() { id = 2, nombre = "Juan Antonio", apellido = "Perez", edad = 20, email = "juan@uai.cl", direccion = "Providencia Santiago", tarjeta = "4770415897972386", contrasena = "12345678" });
             * db.Personas.AddOrUpdate(new Persona() { id = 3, nombre = "José Eduardo", apellido = "Lopez", edad = 30, email = "jose@uai.cl", direccion = "Providencia Santiago", tarjeta = "4770415897972386", contrasena = "12345678" });
             * db.Personas.AddOrUpdate(new Persona() { id = 4, nombre = "Luis José", apellido = "Gutierrez", edad = 40, email = "luis@uai.cl", direccion = "Providencia Santiago", tarjeta = "4770415897972386", contrasena = "12345678" });
             * db.Personas.AddOrUpdate(new Persona() { id = 5, nombre = "Pepe Andres", apellido = "Alvares", edad = 50, email = "pepe@uai.cl", direccion = "Providencia Santiago", tarjeta = "4770415897972386", contrasena = "12345678" });
             */
        }
    }
}
