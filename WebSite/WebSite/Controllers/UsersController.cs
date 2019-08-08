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
    public class UsersController : Controller
    {
        private WebSiteContext db = new WebSiteContext();

        public ActionResult Index(int limit = 10, int offset = 0)
        {
            List<User> list = db.Users
                .OrderBy(p => p.Id)
                .Skip(offset)
                .Take(limit)
                .Select(u => new { Id = u.Id, Username = u.Username, Password = u.Password, IsActive = u.IsActive }).ToList()
                .Select(u => new User() { Id = u.Id, Username = u.Username, Password = u.Password, IsActive = u.IsActive }).ToList();

            Int32 Count = db.Users.Count();

            Indexer<User> model = new Indexer<User>(list, Count, limit, offset);

            return View(model);
        }

        public ActionResult Details(int? id)
        {
            return LoadViewModel(id, "Details");
        }

        public ActionResult Create(int PersonId)
        {
            ViewBag.PersonName = db.People.Where(p => p.Id == PersonId).Select(p => p.Name + " " + p.Surname).FirstOrDefault();
            ViewBag.PersonId = PersonId + "";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonName = db.People.Where(p => p.Id == user.PersonId).Select(p => p.Name + " " + p.Surname).FirstOrDefault();
            ViewBag.PersonId = user.PersonId + "";

            return View(user);
        }

        public ActionResult Edit(int? id)
        {
            return LoadViewModel(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Delete(int? id)
        {
            return LoadViewModel(id, "Delete");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private ActionResult LoadViewModel(int? id, String view)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            User user = db.Users.Find(id);

            if (user == null)
                return HttpNotFound();

            user.PasswordValidation = user.Password;
            
            return View(view, user);
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
