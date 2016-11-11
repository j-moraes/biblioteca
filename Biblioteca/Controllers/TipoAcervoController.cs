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
    public class TipoAcervoController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /TipoAcervo/

        public ActionResult Index()
        {
            return View(db.TipoAcervoModels.ToList());
        }
        [HttpPost]
        public ActionResult Index(String pesquisar)
        {
            var acervo = db.TipoAcervoModels.Where(b => b.Descricao.Contains(pesquisar));
            return View(acervo.ToList());
        }

        //
        // GET: /TipoAcervo/Details/5

        public ActionResult Details(int id = 0)
        {
            TipoAcervoModel tipoacervomodel = db.TipoAcervoModels.Find(id);
            if (tipoacervomodel == null)
            {
                return HttpNotFound();
            }
            return View(tipoacervomodel);
        }

        //
        // GET: /TipoAcervo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoAcervo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoAcervoModel tipoacervomodel)
        {
            if (ModelState.IsValid)
            {
                db.TipoAcervoModels.Add(tipoacervomodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoacervomodel);
        }

        //
        // GET: /TipoAcervo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TipoAcervoModel tipoacervomodel = db.TipoAcervoModels.Find(id);
            if (tipoacervomodel == null)
            {
                return HttpNotFound();
            }
            return View(tipoacervomodel);
        }

        //
        // POST: /TipoAcervo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoAcervoModel tipoacervomodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoacervomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoacervomodel);
        }

        //
        // GET: /TipoAcervo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TipoAcervoModel tipoacervomodel = db.TipoAcervoModels.Find(id);
            if (tipoacervomodel == null)
            {
                return HttpNotFound();
            }
            return View(tipoacervomodel);
        }

        //
        // POST: /TipoAcervo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoAcervoModel tipoacervomodel = db.TipoAcervoModels.Find(id);
            db.TipoAcervoModels.Remove(tipoacervomodel);
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