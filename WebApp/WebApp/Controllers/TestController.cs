using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class TestController : Controller
    {
        private WebAppContext db = new WebAppContext();

        // https://msdn.microsoft.com/en-us/library/system.web.mvc.actionresult(v=vs.118).aspx
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult ViewResult()
        {
            return View("Result");
        }

        public FileResult FileResult()
        {
            String path = Server.MapPath("~/Content/Files/ASP.NET and Web Programming.pdf");
            return File(path, "application/pdf", "documentation.pdf");
        }

        // https://en.wikipedia.org/wiki/Media_type
        public ContentResult ContentResult()
        {
            return Content("Text Content Result", "text/plain");
        }

        // https://en.wikipedia.org/wiki/JSON
        public JsonResult JsonResult()
        {
            return Json(db.People.ToList(), JsonRequestBehavior.AllowGet);
        }

        public RedirectResult RedirectResult()
        {
            return Redirect("https://www.google.com");
        }

        public RedirectToRouteResult RedirectActionResult()
        {
            return RedirectToAction("About", "Home");
        }

        public RedirectToRouteResult RedirectRouteResult()
        {
            return RedirectToRoute("HomeIndex");
        }

        // https://en.wikipedia.org/wiki/List_of_HTTP_status_codes
        public HttpStatusCodeResult HttpStatusCodeResult()
        {
            return new HttpStatusCodeResult(301, "This page is currently not available.");
        }

        // https://en.wikipedia.org/wiki/Query_string
        public JsonResult JsonResultQueryString(int limit = 5, int offset = 0)
        {
            return Json(db.People.OrderBy(v => v.PersonID).Skip(offset).Take(limit).ToList(), JsonRequestBehavior.AllowGet);
        }

        // https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods
        [HttpGet]
        public ViewResult HttpGetResult()
        {
            return View("GetResult");
        }

        [HttpPost]
        public ViewResult HttpPostResult()
        {
            return View("PostResult");
        }

        [HttpPost]
        public JsonResult HttpPostPayloadResult(int id = 0)
        {
            return Json(db.People.Find(id));
        }

        public ViewResult UsingViewBagResult(String name = "", Int32 age = 0)
        {
            ViewBag.name = name;
            ViewBag.age = age;
            return View();
        }

        public ViewResult UsingViewDataResult(String product = "", Int32 quantity = 0)
        {
            ViewData["product"] = product;
            ViewData["quantity"] = quantity;
            return View();
        }

        public ViewResult ModelResult(int id = 0)
        {
            return View(db.People.Find(id));
        }

        public ViewResult RazorResult()
        {
            return View(db.People.ToList());
        }

        public ViewResult RawResult()
        {
            ViewBag.Data = "<script>alert('Give me all your money')</script>";

            return View();
        }

        public ViewResult LinksResult()
        {
            return View();
        }

        public ViewResult RenderActionResult()
        {
            return View();
        }

        public ViewResult ActionResult()
        {
            return View();
        }

        [ChildActionOnly]
        public ViewResult BackResult()
        {
            return View();
        }

        public ViewResult DisplayResult(int id = 0)
        {
            ViewBag.Data = db.People.Find(id);
            return View();
        }

        public ViewResult EditorResult(int id = 0)
        {
            ViewBag.Data = db.People.Find(id);
            return View();
        }

    }
}