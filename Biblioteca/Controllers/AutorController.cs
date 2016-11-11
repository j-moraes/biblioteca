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
    public class AutorController : Controller
    {
        private UsersContext db = new UsersContext();

        [HttpPost]
        public ActionResult Index(String Pesquisar)
        {
            var autor = db.AutoresModels.Where(b => b.Nome.Contains(Pesquisar)||b.Nacionalidade.Contains(Pesquisar));
            return View(autor.ToList());

        }
        //
        // GET: /Autor/

        public ActionResult Index()
        {
            return View(db.AutoresModels.ToList());
        }

        //
        // GET: /Autor/Details/5

        public ActionResult Details(int id = 0)
        {
            AutoresModel autoresmodel = db.AutoresModels.Find(id);
            if (autoresmodel == null)
            {
                return HttpNotFound();
            }
            return View(autoresmodel);
        }

        //
        // GET: /Autor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Autor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AutoresModel autoresmodel)
        {
            if (ModelState.IsValid)
            {
                db.AutoresModels.Add(autoresmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(autoresmodel);
        }

        //
        // GET: /Autor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AutoresModel autoresmodel = db.AutoresModels.Find(id);
            if (autoresmodel == null)
            {
                return HttpNotFound();
            }
            return View(autoresmodel);
        }

        //
        // POST: /Autor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AutoresModel autoresmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autoresmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autoresmodel);
        }

        //
        // GET: /Autor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AutoresModel autoresmodel = db.AutoresModels.Find(id);
            if (autoresmodel == null)
            {
                return HttpNotFound();
            }
            return View(autoresmodel);
        }

        //
        // POST: /Autor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AutoresModel autoresmodel = db.AutoresModels.Find(id);
            db.AutoresModels.Remove(autoresmodel);
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