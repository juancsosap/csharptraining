namespace WebSite.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebSite.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebSiteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebSiteContext db)
        {

            /*
            List<Person> people = new List<Person>();

            people.Add(new Person() { Id = 1, Rut = "23.914.881-6", Name = "Juan Carlos", Surname = "Sosa Peña", Age = 36, Inscription = DateTime.Now, Address = "Huechuraba", Phone = "+56946327016", Email = "juan.c.sosa.p@gmail.com" });
            people.Add(new Person() { Id = 2, Rut = "23.914.890-5", Name = "Ana Griselda", Surname = "Prada Perez", Age = 35, Inscription = DateTime.Now, Address = "Huechuraba", Phone = "+56954273471", Email = "griselda.prada@gmail.com" });
            people.Add(new Person() { Id = 3, Rut = "23.855.408-K", Name = "Sarah Eliana", Surname = "Sosa Prada", Age = 6, Inscription = DateTime.Now, Address = "Huechuraba", Email = "sarah.e.sosa.p@gmail.com" });
            people.Add(new Person() { Id = 4, Rut = "24.486.614-K", Name = "Jadash Amaryah", Surname = "Sosa Prada", Age = 4, Inscription = DateTime.Now, Address = "Huechuraba", Email = "jadash.a.sosa.p@gmail.com" });

            foreach (Person person in people)
            {
                db.People.Attach(person);
                db.People.AddOrUpdate(person);
            }

                

            db.Users.AddOrUpdate(new User() { Id = 1, Username = "juan.c.sosa.p", Password = "12345678", IsActive = true, PersonNav = people[0] });
            db.Users.AddOrUpdate(new User() { Id = 2, Username = "ana.g.prada.p", Password = "qwertyui", IsActive = true, PersonNav = people[1] });
            db.Users.AddOrUpdate(new User() { Id = 3, Username = "sarah.e.sosa.p", Password = "asdfghjk", IsActive = false, PersonNav = people[2] });
            db.Users.AddOrUpdate(new User() { Id = 4, Username = "jadash.a.sosa.p", Password = "zxcvbnm,", IsActive = false, PersonNav = people[3] });
            */

            //Person p = db.People.Add(new Person() { Id = 1, Rut = "23.914.881-6", Name = "Juan Carlos", Surname = "Sosa Peña", Age = 36, Inscription = DateTime.Now, Address = "Huechuraba", Phone = "+56946327016", Email = "juan.c.sosa.p@gmail.com" });
            //User u = db.Users.Add(new User() { Id = 1, Username = "juan.c.sosa.p", Password = "12345678", IsActive = true, PersonId = p });

            //db.SaveChanges();
        }
    }
}
