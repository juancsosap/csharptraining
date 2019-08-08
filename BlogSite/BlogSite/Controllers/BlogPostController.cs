using BlogSite.Models;
using BlogSite.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    [Authorize]
    public class BlogPostController :
        GenericController<BlogPost,
                          IndexableGenericRepository<ApplicationDbContext,
                                                     BlogPost>,
                          ApplicationDbContext>
    { }
}
