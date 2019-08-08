using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestedApp.Models;
using TestedApp.Models.DAO;

namespace TestedApp.Controllers
{
    public abstract class GenericController<T> : Controller where T : class, IIndexable
    {
        private IDAO<T> db;

        public GenericController(IDAO<T> db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            return View(db.RetriveAll());
        }

        public ActionResult Details(int? id)
        {
            return prepareGetAction(id, "Details");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(T model)
        {
            return preparePostAction(model, "Edit", m => db.Create(m));
        }

        public ActionResult Edit(int? id)
        {
            return prepareGetAction(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(T model)
        {
            return preparePostAction(model, "Edit", m => db.Update(m));
        }

        public ActionResult Delete(int? id)
        {
            return prepareGetAction(id, "Delete");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        private ActionResult prepareGetAction(int? id, String view)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T model = db.Retrive(id.Value);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(view, model);
        }

        [ChildActionOnly]
        private ActionResult preparePostAction(T model, String view, Action<T> action)
        {
            if (ModelState.IsValid)
            {
                action.Invoke(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}
