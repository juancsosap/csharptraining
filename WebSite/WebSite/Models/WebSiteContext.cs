using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using WebSite.Tools;

namespace WebSite.Models
{
    public class WebSiteContext : DbContext
    {
        public WebSiteContext() : base("DefaultConnection")
        {
            Database.SetInitializer<WebSiteContext>(new DropCreateDatabaseIfModelChanges<WebSiteContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types<String>().Where(item => item.Name.EndsWith("Validation")).Configure(item => item.Ignore());

            modelBuilder.Entity<User>().HasRequired(user => user.PersonNav).WithOptional(person => person.UserNav);

            base.OnModelCreating(modelBuilder);
        }

        protected override bool ShouldValidateEntity(DbEntityEntry entityEntry)
        {
            if (entityEntry.State == EntityState.Deleted)
                return true;

            return base.ShouldValidateEntity(entityEntry);
        }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            if(entityEntry.Entity is User && entityEntry.State == EntityState.Deleted)
            {
                User entity = entityEntry.Entity as User;

                if (entity.IsActive)
                {
                    DbValidationError error = new DbValidationError("IsActive", "Could not be deleted People in Active state");
                    return new DbEntityValidationResult(entityEntry, new DbValidationError[] { error });
                }
            }

            return base.ValidateEntity(entityEntry, items);
        }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries();

            if (entities != null)
                foreach (var entity in entities.Where(i => i.State != EntityState.Unchanged))
                    AuditChanges.Audit(entity);

            return base.SaveChanges();
        }

        public DbSet<Person> People { get; set; }
        public DbSet<User> Users { get; set; }
    }
}