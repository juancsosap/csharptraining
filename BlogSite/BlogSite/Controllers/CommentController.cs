using BlogSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    [Authorize]
    public class CommentController :
       GenericController<Comment,
                         IndexableGenericRepository<ApplicationDbContext,
                                                    Comment>,
                         ApplicationDbContext>
    {
        protected override RedirectToRouteResult GetIndex()
        {
            return RedirectToAction("Index", "BlogPost");
        }

        public override ActionResult Index(int limit = 10, int offset = 0)
        {
            return GetIndex();
        }
    }
}