using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Tools;

namespace WebApp.Controllers
{
    public class FormsController : Controller
    {
        WebAppContext db = new WebAppContext(); 

        public ActionResult Index(Int32? id)
        {
            return View(id);
        }

        [ChildActionOnly]
        public PartialViewResult _DropDownPeople(Person person)
        {
            Func<Person, String> text = p => p.Surname.ToUpper() + ", " + p.Firstname;
            Func<Person, String> value = p => p.PersonID.ToString();
            Predicate<Person> disable = p => !p.Active;
            List<SelectListItem> list = ViewTools.ToSelectListItem<Person>(person, db.People.ToList(), text, value, disable);

            return PartialView("_DropDownPeople", list);
        }

        [ChildActionOnly]
        public PartialViewResult _DropDownUserStatus(Int32 id)
        {
            return PartialView("_DropDownUserStatus", db.Users.Find(id).Status);
        }
    }
}