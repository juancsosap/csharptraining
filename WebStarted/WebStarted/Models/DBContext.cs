using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebStarted.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base("DefaultConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Login> Logins { get; set; }
    }
}