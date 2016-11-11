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
    public class FeriadoController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Feriado/

        public ActionResult Index()
        {
            return View(db.FeriadoModels.ToList());
        }

        //
        // GET: /Feriado/Details/5

        public ActionResult Details(int id = 0)
        {
            FeriadoModel feriadomodel = db.FeriadoModels.Find(id);
            if (feriadomodel == null)
            {
                return HttpNotFound();
            }
            return View(feriadomodel);
        }

        //
        // GET: /Feriado/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Feriado/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeriadoModel feriadomodel)
        {
            if (ModelState.IsValid)
            {
                db.FeriadoModels.Add(feriadomodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(feriadomodel);
        }

        //
        // GET: /Feriado/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FeriadoModel feriadomodel = db.FeriadoModels.Find(id);
            if (feriadomodel == null)
            {
                return HttpNotFound();
            }
            return View(feriadomodel);
        }

        //
        // POST: /Feriado/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FeriadoModel feriadomodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feriadomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feriadomodel);
        }

        //
        // GET: /Feriado/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FeriadoModel feriadomodel = db.FeriadoModels.Find(id);
            if (feriadomodel == null)
            {
                return HttpNotFound();
            }
            return View(feriadomodel);
        }

        //
        // POST: /Feriado/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeriadoModel feriadomodel = db.FeriadoModels.Find(id);
            db.FeriadoModels.Remove(feriadomodel);
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