using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BlogSite.Models.Repositories
{
    public class BlogPostRepository : IndexableGenericRepository<ApplicationDbContext, BlogPost>
    {
        public BlogPostRepository(ApplicationDbContext db) : base(db) { }
        public BlogPostRepository() : base() { }
    }
}