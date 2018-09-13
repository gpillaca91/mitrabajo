using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using RankingDocentes.Models;

namespace RankingDocentes.Controllers
{
    public class UsuarioController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.Carrera).Include(u => u.TipoUsuario);
            return View(usuario.ToList());
        }

        public ActionResult Register()
        {
            ViewBag.nIdCarrera = new SelectList(db.Carrera, "nIdCarrera", "cNombre");
            ViewBag.nIdTipoUsuario = new SelectList(db.TipoUsuario, "nIdTipoUsuario", "cDescTipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Usuario usuario)
        {
            string dominio = "upc.edu.pe";
            Regex regex = new Regex(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$");
            Match match = regex.Match(usuario.cCorreo);

            if (String.IsNullOrEmpty(usuario.cNombres))
            {
                ViewBag.Message = "Debe Ingresar Nombres";
            }

            else if (String.IsNullOrEmpty(usuario.cApeMaterno))
            {
                ViewBag.Message = "Debe Ingresar Apellido Paterno";
            }

            else if (String.IsNullOrEmpty(usuario.cApeMaterno))
            {
                ViewBag.Message = "Debe Ingresar Apellido Materno";
            }

            else if (String.IsNullOrEmpty(usuario.nIdCarrera.ToString()))
            {
                ViewBag.Message = "Debe Ingresar una carrera";
            }

            else if (String.IsNullOrEmpty(usuario.cCorreo))
            {
                ViewBag.Message = "Debe Ingresar Correo";
            }

            else if (!match.Success || !usuario.cCorreo.Contains(dominio))
            {
                ViewBag.Message = "Debe ingresar un correo válido";
            }

            else if (String.IsNullOrEmpty(usuario.cContrasena))
            {
                ViewBag.Message = "Debe ingresar una contraseña";
            }

            else if (!usuario.cContrasena.Equals(usuario.cConfirmarContraseña))
            {
                ViewBag.Message = "Las contraseñas no coinciden";
            }

            else if (!usuario.cCorreo.Contains(dominio))
            {
                ViewBag.Message = "Debe ingresar un correo UPC";
            }

            else
            {
                usuario.cEstado = "1";
                usuario.nIdTipoUsuario = 2;

                db.Usuario.Add(usuario);
                db.SaveChanges();
                //login
                Session["IdUsuario"] = usuario.nIdUsuario.ToString();
                Session["Nombres"] = usuario.cNombres.ToString() + ' ' + usuario.cApePaterno.ToString() + ' ' + usuario.cApeMaterno.ToString();
                Session["TipoUsuario"] = usuario.nIdTipoUsuario.ToString();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.nIdCarrera = new SelectList(db.Carrera, "nIdCarrera", "cNombre", usuario.nIdCarrera);
            ViewBag.nIdTipoUsuario = new SelectList(db.TipoUsuario, "nIdTipoUsuario", "cDescTipoUsuario", usuario.nIdTipoUsuario);

            return View(usuario);
        }

        //
        // GET: /Usuario/Details/5

        public ActionResult Details(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario usuario)
        {
            if ((usuario.cCorreo != null) && (usuario.cContrasena != null))
            {
                var obj = db.Usuario.Where(a => a.cCorreo.Equals(usuario.cCorreo) && a.cContrasena.Equals(usuario.cContrasena)).FirstOrDefault();
                if (obj != null)
                {
                    Session["IdUsuario"] = obj.nIdUsuario.ToString();
                    Session["Nombres"] = obj.cNombres.ToString() + ' ' + obj.cApePaterno.ToString() + ' ' + obj.cApeMaterno.ToString();
                    Session["TipoUsuario"] = obj.nIdTipoUsuario.ToString();
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.Error = "Usuario o Contraseña incorrecta.";
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            ViewBag.nIdCarrera = new SelectList(db.Carrera, "nIdCarrera", "cNombre");
            ViewBag.nIdTipoUsuario = new SelectList(db.TipoUsuario, "nIdTipoUsuario", "cDescTipoUsuario");
            return View();
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            usuario.cEstado = "1";
            usuario.nIdTipoUsuario = 1;

            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.nIdCarrera = new SelectList(db.Carrera, "nIdCarrera", "cNombre", usuario.nIdCarrera);
            ViewBag.nIdTipoUsuario = new SelectList(db.TipoUsuario, "nIdTipoUsuario", "cDescTipoUsuario", usuario.nIdTipoUsuario);
            return View(usuario);
        }

        //
        // GET: /Usuario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.nIdCarrera = new SelectList(db.Carrera, "nIdCarrera", "cNombre", usuario.nIdCarrera);
            ViewBag.nIdTipoUsuario = new SelectList(db.TipoUsuario, "nIdTipoUsuario", "cDescTipoUsuario", usuario.nIdTipoUsuario);
            return View(usuario);
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nIdCarrera = new SelectList(db.Carrera, "nIdCarrera", "cNombre", usuario.nIdCarrera);
            ViewBag.nIdTipoUsuario = new SelectList(db.TipoUsuario, "nIdTipoUsuario", "cDescTipoUsuario", usuario.nIdTipoUsuario);
            return View(usuario);
        }

        //
        // GET: /Usuario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Usuario/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RestaurarContraseña() {
            return View();
        }//RestaurarContraseña

        public ActionResult ReportarInformacion() {

            return View("ReportarInfoFalsa");
        }//ReportarInformacion

        public ActionResult HistorialConsultas() {
            return View();
        }//HistorialConsultas


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}