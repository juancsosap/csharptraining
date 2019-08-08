using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestedApp.Models;
using TestedApp.Models.DAO;

namespace TestedApp.Controllers
{
    public class PersonController : GenericController<Person>
    {
        public PersonController(IDAO<Person> db) : base(db) { }
    }
}