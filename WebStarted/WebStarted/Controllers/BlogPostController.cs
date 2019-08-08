using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStarted.Models;
using WebStarted.Services;

namespace WebStarted.Controllers
{
    public class BlogPostController : Controller
    {
        private BlogPostRepository repo = new BlogPostRepository();

        // GET: BlogPost
        public ActionResult Index(Int32 limit = 10, Int32 offset = 0)
        {
            return View(repo.Get(limit, offset));
        }

        // GET: BlogPost/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.Get(id));
        }

        // GET: BlogPost/Create
        public ActionResult Create()
        {
            return View(new BlogPost() { Category = BlogPostCategory.FUN });
        }

        // POST: BlogPost/Create
        [HttpPost]
        public ActionResult Create(BlogPost model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Post(model);
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex) { }
            return View(model);
        }

        // GET: BlogPost/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlogPost/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogPost/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlogPost/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
