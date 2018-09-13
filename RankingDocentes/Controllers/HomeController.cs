using RankingDocentes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RankingDocentes.Controllers
{
    public class HomeController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        public ActionResult Index()
        {
            ViewBag.Carreras = new SelectList(db.Carrera.ToList(), "nIdCarrera", "cNombre");
            ViewBag.Cursos = new SelectList(db.Curso.ToList(), "nIdCurso", "cNombre");
            return View();
        }

        public ActionResult GetPartialConsulta(int? carrera, int? curso)
        {
            var result = db.RankingDocente;

            if (carrera == null)
            {
                var resultx = result.Where(x => x.DetalleDocente.Curso_nIdCurso == curso).OrderByDescending(x=>x.nPuntuacionPromedio);
                return PartialView("_PartialConsulta", resultx);
            }

            else if (curso == null)
            {
                var resultx = result.Where(x => x.DetalleDocente.Carrera_nIdCarrera == carrera).OrderByDescending(x => x.nPuntuacionPromedio);
                return PartialView("_PartialConsulta", resultx);
            }

            else
            {
                var resultx = result.Where(x => 
                                           x.DetalleDocente.Carrera_nIdCarrera == carrera && 
                                           x.DetalleDocente.Curso_nIdCurso == curso)
                                           .OrderByDescending(x => x.nPuntuacionPromedio);
                return PartialView("_PartialConsulta", resultx);
            }           
        }
    }
}