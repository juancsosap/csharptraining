using BlogSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public abstract class GenericController<T, R, C> : Controller 
           where R : IndexableGenericRepository<C, T>, new() 
           where C : DbContext, new() 
           where T : class, Indexable, new()
    {
        private R repo = new R();
        
        protected virtual RedirectToRouteResult GetIndex()
        {
            return RedirectToAction("Index");
        }

        public virtual ActionResult Index(int limit = 10, int offset = 0)
        {
            return View(repo.GetAll(limit, offset));
        }

        public virtual ActionResult Details(int id)
        {
            return PrepareGetView("Details", id);
        }

        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(T model)
        {
            return PreparePostView("Create", model, m => repo.Add(m));
        }

        public virtual ActionResult Edit(int id)
        {
            return PrepareGetView("Edit", id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(T model)
        {
            return PreparePostView("Create", model, m => repo.Edit(m));
        }

        public virtual ActionResult Delete(int id)
        {
            return PrepareGetView("Delete", id);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            if (!repo.Exist(id))
                return HttpNotFound();
            repo.Delete(id);
            return GetIndex();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                repo.Dispose();
            base.Dispose(disposing);
        }

        [ChildActionOnly]
        public virtual ActionResult PrepareGetView(string name, int id)
        {
            T model = repo.GetById(id);
            if (model == null)
                return HttpNotFound();
            return View(name, model);
        }

        [ChildActionOnly]
        public virtual ActionResult PreparePostView<T>(string name, T model, Action<T> operation)
        {
            if (!ModelState.IsValid)
                return View(name, model);
            operation.Invoke(model);
            return GetIndex();
        }

    }

}
