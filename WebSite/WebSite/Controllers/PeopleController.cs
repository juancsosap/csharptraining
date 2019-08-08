using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using WebSite.Models.Views;

namespace WebSite.Controllers
{
    public class PeopleController : Controller
    {
        private WebSiteContext db = new WebSiteContext();

        public ActionResult Index(int limit = 10, int offset = 0)
        {
            List<Person> list = db.People
                .OrderBy(p => p.Id)
                .Skip(offset)
                .Take(limit)
                .Select(p => new { Id = p.Id, Rut = p.Rut, Name = p.Name, Surname = p.Surname, Email = p.Email, Phone = p.Phone }).ToList()
                .Select(p => new Person() { Id = p.Id, Rut = p.Rut, Name = p.Name, Surname = p.Surname, Email = p.Email, Phone = p.Phone }).ToList();

            Int32 Count = db.People.Count();

            Indexer<Person> model = new Indexer<Person>(list, Count, limit, offset);

            return View(model);
        }

        public ActionResult Details(int? id)
        {
            return LoadViewModel(id, "Details");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        public ActionResult Edit(int? id)
        {
            return LoadViewModel(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        public ActionResult Delete(int? id)
        {
            return LoadViewModel(id, "Delete");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private ActionResult LoadViewModel(int? id, String view)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Person person = db.People.Find(id);

            if (person == null)
                return HttpNotFound();

            person.EmailValidation = person.Email;
            
            return View(view, person);
        }

        public JsonResult RutValidator(String Rut)
        {
            bool IsValid = Tools.Validators.RutValidator.IsValid(Rut);
            return Json(IsValid, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
