namespace WebStarted.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebStarted.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebStarted.Models.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DBContext db)
        {
            // ----USERS-----------------------------------------------------------------------------------
            User user1 = new User()
            {
                Id = 1,
                Name = "Juan Sosa",
                Email = "jsosa@gmail.com",
                Username = "juan.sosa",
                Password = "12345"
            };
            User user2 = new User()
            {
                Id = 2,
                Name = "Carlos Peña",
                Email = "cpena@hotmail.com",
                Username = "carlos.pena",
                Password = "abcde"
            };

            db.Users.AddOrUpdate(u => u.Id, user1);
            db.Users.AddOrUpdate(u => u.Id, user2);

            // ----BLOGPOSTS-------------------------------------------------------------------------------
            BlogPost bpost1 = new BlogPost()
            {
                Id = 1,
                // AuthorId = user1.Id,
                Title = "Programing in ASP.NET",
                Publication = new DateTime(2018, 5, 1),
                Content = "It's very fun the programing with ASP.NET"
            };
            BlogPost bpost2 = new BlogPost()
            {
                Id = 2,
                // AuthorId = user1.Id,
                Title = "Troubleshooting ASP.NET",
                Publication = new DateTime(2018, 5, 5),
                Content = "It's very easy troubleshooting ASP.NET programs"
            };
            BlogPost bpost3 = new BlogPost()
            {
                Id = 3,
                // AuthorId = user2.Id,
                Title = "Working as a ASP.NET programer",
                Publication = new DateTime(2018, 5, 10),
                Content = "There are many opportunities for ASP.NET programers"
            };

            db.BlogPosts.AddOrUpdate(bp => bp.Id, bpost1);
            db.BlogPosts.AddOrUpdate(bp => bp.Id, bpost2);
            db.BlogPosts.AddOrUpdate(bp => bp.Id, bpost3);

            // ----COMMENTS--------------------------------------------------------------------------------
            Comment comment1 = new Comment()
            {
                Id = 1,
                // AuthorId = user2.Id,
                BlogPost = bpost1,
                Content = "I agree",
                Publication = new DateTime(2018, 5, 2)
            };
            Comment comment2 = new Comment()
            {
                Id = 2,
                // AuthorId = user1.Id,
                BlogPost = bpost3,
                Content = "All the work must use ASP.NET",
                Publication = new DateTime(2018, 5, 12)
            };
            Comment comment3 = new Comment()
            {
                Id = 3,
                // AuthorId = user2.Id,
                BlogPost = bpost3,
                Content = "Nooooo, Its better to be only few...",
                Publication = new DateTime(2018, 5, 14)
            };

            db.Comments.AddOrUpdate(c => c.Id, comment1);
            db.Comments.AddOrUpdate(c => c.Id, comment2);
            db.Comments.AddOrUpdate(c => c.Id, comment3);

            db.SaveChanges();
        }
    }
}
