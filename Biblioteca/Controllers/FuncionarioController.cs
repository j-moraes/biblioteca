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
    public class FuncionarioController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Funcionario/

        public ActionResult Index()
        {
            return View(db.FuncionarioModels.ToList());
        }

        //
        // GET: /Funcionario/Details/5

        public ActionResult Details(int id = 0)
        {
            FuncionarioModel funcionariomodel = db.FuncionarioModels.Find(id);
            if (funcionariomodel == null)
            {
                return HttpNotFound();
            }
            return View(funcionariomodel);
        }

        //
        // GET: /Funcionario/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Funcionario/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FuncionarioModel funcionariomodel)
        {
            if (ModelState.IsValid)
            {
                db.FuncionarioModels.Add(funcionariomodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(funcionariomodel);
        }

        //
        // GET: /Funcionario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FuncionarioModel funcionariomodel = db.FuncionarioModels.Find(id);
            if (funcionariomodel == null)
            {
                return HttpNotFound();
            }
            return View(funcionariomodel);
        }

        //
        // POST: /Funcionario/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FuncionarioModel funcionariomodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionariomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcionariomodel);
        }

        //
        // GET: /Funcionario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FuncionarioModel funcionariomodel = db.FuncionarioModels.Find(id);
            if (funcionariomodel == null)
            {
                return HttpNotFound();
            }
            return View(funcionariomodel);
        }

        //
        // POST: /Funcionario/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FuncionarioModel funcionariomodel = db.FuncionarioModels.Find(id);
            db.FuncionarioModels.Remove(funcionariomodel);
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