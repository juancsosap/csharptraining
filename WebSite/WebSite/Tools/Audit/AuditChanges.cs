using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace WebSite.Tools
{
    public class AuditChanges
    {
        public static void Audit(DbEntityEntry entity)
        {
            Console.WriteLine(entity);
        }
    }
}