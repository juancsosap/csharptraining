namespace BlogSite.Migrations
{
    using BlogSite.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext db)
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            if (roleManager.FindByName("Administrators") == null)
                roleManager.Create(new IdentityRole("Administrators"));

            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
            if (userManager.FindByName("admin") == null)
                userManager.Create(new IdentityUser() { UserName = "admin", Email = "admin@blogsite.com" }, "Pa$$w0rd");

            IdentityUser user = userManager.FindByName("admin");
            if (!userManager.IsInRole(user.Id, "Administrators"))
                userManager.AddToRole(user.Id, "Administrators");       }
    }
}
