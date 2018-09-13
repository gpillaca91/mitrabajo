using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RankingDocentes.Controllers
{
    public class DocenteController : Controller
    {
        //
        // GET: /Docente/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DocenteSugerir()
        {

            return View();
        }
        public ActionResult DocenteCalificar() {
            return View();
        }
        public ActionResult DocenteAprobar()
        {
            return View();
        }

    }
}
