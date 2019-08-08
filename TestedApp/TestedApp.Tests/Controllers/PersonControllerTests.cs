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
    public class PersonControllerTests
    {
        [Test]
        public void PersonController_Index()
        {
            // Arrange
            IDAO<Person> db = new DAOMemory<Person>();

            db.Create(new Person() { id = 1, name = "Juan Carlos Sosa", age = 36 });
            db.Create(new Person() { id = 2, name = "Ana Griselda Prada", age = 35 });
            db.Create(new Person() { id = 3, name = "Beatriz Antonia Perez", age = 62 });

            PersonController controller = new PersonController(db);

            // Act
            ViewResult view = controller.Index() as ViewResult;
            List<Person> model = view.Model as List<Person>;
            
            // Assert
            Assert.IsInstanceOf<List<Person>>(model);
        }
    }
}