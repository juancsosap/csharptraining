using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Register()
        {
            return View();
        }
    }
}