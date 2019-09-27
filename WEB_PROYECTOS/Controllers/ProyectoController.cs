using ENTIDAD;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB_PROYECTOS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProyectoController : Controller
    {
        // GET: Proyecto
        public ActionResult Index()
        {
            var proyectos = ProyectoCN.ListarProyectos();
            return View(proyectos);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Proyecto proyecto)
        {
            try
            {
                if (proyecto.NombreProyecto == null)
                    return Json(new { ok = false, msg = "Debe ingresar el nombre del proyecto" }, JsonRequestBehavior.AllowGet);

                ProyectoCN.Agregar(proyecto);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
                //ModelState.AddModelError("", "Ocurrió un error al agregar un Proyecto");
                //return View();
            }
        }

        public ActionResult Detalles(int id)
        {
            var proyecto = ProyectoCN.ObtenerProyecto(id);
            return View(proyecto);
        }

        public ActionResult Editar(int id)
        {
            var proyecto = ProyectoCN.ObtenerProyecto(id);
            return View(proyecto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Proyecto proyecto)
        {
            try
            {
                ProyectoCN.Editar(proyecto);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Eliminar(int identificador)
        {
            try
            {
                ProyectoCN.Eliminar(identificador);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}