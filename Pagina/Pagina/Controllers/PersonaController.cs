using Pagina.Models;
using Pagina.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pagina.Controllers
{
    public class PersonaController : Controller
    {
        private DAO<Persona> db = new DAOEF<Persona, AppDBContext>();

        /*public PersonaController(DAO<Persona> dao)
        {
            this.db = dao;
        }*/

        public ActionResult Indice()
        {
            return View(db.ObtenerTodas());
        }

        public ActionResult Detalles(int? id)
        {
            return prepareGetAction(id, "Detalles");
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Persona p)
        {
            return preparePostAction(p, "Crear", per => db.Crear(per));
        }

        public ActionResult Editar(int? id)
        {
            return prepareGetAction(id, "Editar");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Persona p)
        {
            return preparePostAction(p, "Editar", per => db.Actualizar(per));
        }

        public ActionResult Borrar(int? id)
        {
            return prepareGetAction(id, "Borrar");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Borrar(Persona p)
        {
            db.Borrar(p);
            return RedirectToAction("Indice");
        }

        [ChildActionOnly]
        private ActionResult prepareGetAction(int? id, String view)
        {
            if (id == null)
            {
                return RedirectToAction("Indice");
            }
            else
            {
                return View(view, db.Obtener(id.Value));
            }
        }

        [ChildActionOnly]
        private ActionResult preparePostAction(Persona p, String view, Action<Persona> metodo)
        {
            if (ModelState.IsValid)
            {
                metodo.Invoke(p);
                return RedirectToAction("Indice");
            }
            else
            {
                return View(view, p);
            }
        }

        [ChildActionOnly]
        public PartialViewResult _Volver()
        {
            return PartialView();
        }

        public JsonResult Validador(int edad)
        {
            return Json(edad % 2 == 0, JsonRequestBehavior.AllowGet);
        }
    }
}
