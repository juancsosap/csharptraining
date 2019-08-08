using TestedApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestedApp.Models.DAO;
using TestedApp.Models;
using System.Web.Mvc;
using NUnit.Framework;

namespace TestedApp.Tests.Controllers
{
    [TestFixture]
    public class DAOMemoryTests
    {
        [Test]
        public void DAOMemory_Create()
        {
            IDAO<Person> db = new DAOMemory<Person>();

            db.Create(new Person() { name = "Juan Carlos Sosa Peña", age = 36 });
            db.Create(new Person() { name = "Ana Griselda Prada Perez", age = 35 });
            
            // First Object Creation
            Assert.AreEqual(36, db.Retrive(1).age);
            // Second Object Creation
            Assert.AreEqual(35, db.Retrive(2).age);
            // Null Object Creation
            Assert.Throws<NullReferenceException>(() => db.Create(null));
        }

        [Test]
        public void DAOMemory_Retrive()
        {
            IDAO<Person> db = new DAOMemory<Person>();
            db.Create(new Person() { name = "Juan Carlos Sosa Peña", age = 36 });
            db.Create(new Person() { name = "Ana Griselda Prada Perez", age = 35 });
            
            // Valid Object Id Retrived
            Assert.AreEqual(36, db.Retrive(1).age);
            // Invalid Object Id Retrive
            Assert.Throws<InvalidOperationException>(() => db.Retrive(3));
        }

        [Test]
        public void DAOMemory_RetriveAll()
        {
            IDAO<Person> db = new DAOMemory<Person>();
            
            // Empty List Retrived
            Assert.IsInstanceOf<List<Person>>(db.RetriveAll());
            Assert.NotNull(db.RetriveAll());

            db.Create(new Person() { name = "Juan Carlos Sosa Peña", age = 36 });
            db.Create(new Person() { name = "Ana Griselda Prada Perez", age = 35 });

            // Filled List Retrived
            Assert.AreEqual(2, db.RetriveAll().Count);
        }

        [Test]
        public void DAOMemory_Update()
        {
            IDAO<Person> db = new DAOMemory<Person>();
            db.Create(new Person() { name = "Juan Carlos Sosa Peña", age = 36 });
            db.Create(new Person() { name = "Ana Griselda Prada Perez", age = 35 });

            // Valid Object Id Updated
            Person p1 = new Person() { id = 1, name = "José Luis Sosa Gill", age = 73 };
            db.Update(p1);
            Assert.AreEqual(73, db.Retrive(1).age);

            // Invalid Object Id Updated
            Person p2 = new Person() { id = 3, name = "Pedro Antonio Perez", age = 15 };
            Assert.Throws<InvalidOperationException>(() => db.Update(p2));
        }

        [Test]
        public void DAOMemory_Delete()
        {
            IDAO<Person> db = new DAOMemory<Person>();
            db.Create(new Person() { name = "Juan Carlos Sosa Peña", age = 36 });
            db.Create(new Person() { name = "Ana Griselda Prada Perez", age = 35 });

            // Valid Object Id Deleted
            db.Delete(1);
            Assert.Throws<InvalidOperationException>(() => db.Retrive(1));
            
            // Invalid Object Id Updated
            Assert.Throws<InvalidOperationException>(() => db.Delete(1));
        }
    }
}