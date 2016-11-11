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
    public class FolhaPagamentoController : Controller
    {
        private UsersContext db = new UsersContext();

        [HttpPost]
        public ActionResult Index(String Pesquisar)
        {
            var folha = db.FolhaPagamentoModels.Where(b => b.Funcionario.Nome.Contains(Pesquisar));
            return View(folha.ToList());
        }

        //
        // GET: /FolhaPagamento/

        public ActionResult Index()
        {
            return View(db.FolhaPagamentoModels.ToList());
        }

        //
        // GET: /FolhaPagamento/Details/5

        public ActionResult Details(int id = 0)
        {
            FolhaPagamentoModel folhapagamentomodel = db.FolhaPagamentoModels.Find(id);
            if (folhapagamentomodel == null)
            {
                return HttpNotFound();
            }
            return View(folhapagamentomodel);
        }

        //
        // GET: /FolhaPagamento/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /FolhaPagamento/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FolhaPagamentoModel folhapagamentomodel)
        {
            if (ModelState.IsValid)
            {
                db.FolhaPagamentoModels.Add(folhapagamentomodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(folhapagamentomodel);
        }

        //
        // GET: /FolhaPagamento/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FolhaPagamentoModel folhapagamentomodel = db.FolhaPagamentoModels.Find(id);
            if (folhapagamentomodel == null)
            {
                return HttpNotFound();
            }
            return View(folhapagamentomodel);
        }

        //
        // POST: /FolhaPagamento/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FolhaPagamentoModel folhapagamentomodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(folhapagamentomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(folhapagamentomodel);
        }

        //
        // GET: /FolhaPagamento/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FolhaPagamentoModel folhapagamentomodel = db.FolhaPagamentoModels.Find(id);
            if (folhapagamentomodel == null)
            {
                return HttpNotFound();
            }
            return View(folhapagamentomodel);
        }

        //
        // POST: /FolhaPagamento/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FolhaPagamentoModel folhapagamentomodel = db.FolhaPagamentoModels.Find(id);
            db.FolhaPagamentoModels.Remove(folhapagamentomodel);
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