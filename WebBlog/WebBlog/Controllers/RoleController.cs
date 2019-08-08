using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBlog.Models;

namespace WebBlog.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        RoleManager<IdentityRole> RoleMng;

        public RoleController()
        {
            RoleMng = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
        }

        public ActionResult Index()
        {
            return View(RoleMng.Roles.ToList());
        }

        public ActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            RoleMng.Create(Role);
            return RedirectToAction("Index");
        }

    }
}