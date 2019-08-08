using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pagina.Controllers
{
    public class InicioController : Controller
    {
        public ActionResult Indice()
        {
            return View();
        }

        public ActionResult SobreNosotros()
        {
            ViewBag.Message = "Tú página de descripción de la aplicación.";

            return View();
        }

        public ActionResult Contacto()
        {
            ViewBag.Message = "Tú página de contacto.";

            return View();
        }

    }
}