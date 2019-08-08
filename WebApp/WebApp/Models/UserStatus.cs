using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public enum UserStatus
    {
        [Description("Activo")]
        Active = 1,

        [Description("Suspendido")]
        Suspended = 2,

        [Description("Bajo Revisión")]
        UnderRevision = 3,

        [Description("Eliminado")]
        Eliminated = 4
    }
}