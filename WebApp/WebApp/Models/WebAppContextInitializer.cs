using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class WebAppContextInitializer : DropCreateDatabaseAlways<WebAppContext>
    {
        protected override void Seed(WebAppContext db)
        {
            db.People.Add(new Person() { Firstname = "Pedro", Surname = "Perez", Age = 50, Active = false, Birthday = new DateTime(1968, 1, 1) });
            db.People.Add(new Person() { Firstname = "Paco", Surname = "Pacheco", Age = 30, Active = true, Birthday = new DateTime(1987, 7, 15) });
            db.People.Add(new Person() { Firstname = "Luis", Surname = "Gütierrez", Age = 15, Active = false, Birthday = new DateTime(2003, 2, 20) });
            db.People.Add(new Person() { Firstname = "Maria", Surname = "Prada", Age = 70, Active = true, Birthday = new DateTime(1947, 5, 15) });
            db.People.Add(new Person() { Firstname = "Ana", Surname = "Irarrazabal", Age = 10, Active = false, Birthday = new DateTime(2007, 10, 10) });

            db.Users.Add(new User() { Username = "pperez", Password = "1234", Status = UserStatus.Suspended });
            db.Users.Add(new User() { Username = "ppacheco", Password = "abcd", Status = UserStatus.Active });
            db.Users.Add(new User() { Username = "lgutierrez", Password = "xyzw", Status = UserStatus.Eliminated });
            db.Users.Add(new User() { Username = "mprada", Password = "+-*/", Status = UserStatus.Active });
            db.Users.Add(new User() { Username = "airarrazabal", Password = ".,:;", Status = UserStatus.UnderRevision });

            db.SaveChanges();
        }
    }
}