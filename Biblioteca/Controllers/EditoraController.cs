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
    public class EditoraController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Editora/

        public ActionResult Index()
        {
            return View(db.EditoraModels.ToList());
        }

        [HttpPost]
        public ActionResult Index (string Pesquisar)
        {
            var nome = db.EditoraModels.Where(b => b.nome.Contains(Pesquisar));
            return View(nome.ToList());     
        }

        //
        // GET: /Editora/Details/5

        public ActionResult Details(int id = 0)
        {
            EditoraModel editoramodel = db.EditoraModels.Find(id);
            if (editoramodel == null)
            {
                return HttpNotFound();
            }
            return View(editoramodel);
        }

        //
        // GET: /Editora/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Editora/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EditoraModel editoramodel)
        {
            if (ModelState.IsValid)
            {
                db.EditoraModels.Add(editoramodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(editoramodel);
        }

        //
        // GET: /Editora/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EditoraModel editoramodel = db.EditoraModels.Find(id);
            if (editoramodel == null)
            {
                return HttpNotFound();
            }
            return View(editoramodel);
        }

        //
        // POST: /Editora/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditoraModel editoramodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editoramodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editoramodel);
        }

        //
        // GET: /Editora/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EditoraModel editoramodel = db.EditoraModels.Find(id);
            if (editoramodel == null)
            {
                return HttpNotFound();
            }
            return View(editoramodel);
        }

        //
        // POST: /Editora/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EditoraModel editoramodel = db.EditoraModels.Find(id);
            db.EditoraModels.Remove(editoramodel);
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