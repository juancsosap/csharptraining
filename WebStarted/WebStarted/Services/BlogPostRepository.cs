using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStarted.Models;
using System.Data.Entity;

namespace WebStarted.Services
{
    public class BlogPostRepository
    {
        public BlogPost Get(Int32 id)
        {
            using(DBContext db = new DBContext())
                return db.BlogPosts.Find(id);
        }

        public List<BlogPost> Get(Int32 limit, Int32 offset)
        {
            using (DBContext db = new DBContext())
                return db.BlogPosts.OrderBy(i => i.Id).Skip(offset).Take(limit).ToList();
        }

        public void Post(BlogPost model)
        {
            using (DBContext db = new DBContext())
            {
                db.BlogPosts.Add(model);
                db.SaveChanges();
            }
        }
    }
}