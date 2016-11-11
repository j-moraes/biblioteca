using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class CadastroUsuarioController : Controller
    {
        private UsersContext db = new UsersContext();
        [HttpPost]
        public ActionResult Index(String Pesquisar)
        {
            var usuario = db.UsuarioModels.Where(b => b.Nome.Contains(Pesquisar));
            return View(usuario.ToList());

        }
        //
        // GET: /CadastroUsuario/
        
        public ActionResult Index()
        {
            return View(db.UsuarioModels.ToList());
        }

        //
        // GET: /CadastroUsuario/Details/5

        public ActionResult Details(int id = 0)
        {
            UsuarioModel usuariomodel = db.UsuarioModels.Find(id);
            if (usuariomodel == null)
            {
                return HttpNotFound();
            }
            return View(usuariomodel);
        }

        //
        // GET: /CadastroUsuario/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CadastroUsuario/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioModel usuariomodel)
        {
            if (ModelState.IsValid)
            {
                db.UsuarioModels.Add(usuariomodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuariomodel);
        }

        //
        // GET: /CadastroUsuario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UsuarioModel usuariomodel = db.UsuarioModels.Find(id);
            if (usuariomodel == null)
            {
                return HttpNotFound();
            }
            return View(usuariomodel);
        }

        //
        // POST: /CadastroUsuario/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioModel usuariomodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuariomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuariomodel);
        }

        //
        // GET: /CadastroUsuario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UsuarioModel usuariomodel = db.UsuarioModels.Find(id);
            if (usuariomodel == null)
            {
                return HttpNotFound();
            }
            return View(usuariomodel);
        }

        //
        // POST: /CadastroUsuario/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioModel usuariomodel = db.UsuarioModels.Find(id);
            db.UsuarioModels.Remove(usuariomodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}