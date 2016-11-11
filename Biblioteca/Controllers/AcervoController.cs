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
    public class AcervoController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Acervo/

        public ActionResult Index()
        {
            return View(db.AcervoModels.ToList());
        }
        [HttpPost]
        public ActionResult Index(string pesquisar)
        {
            var acervo = db.AcervoModels.Where(b => b.Descricao.Contains(pesquisar));
            return View(acervo.ToList());
        }

        //
        // GET: /Acervo/Details/5

        public ActionResult Details(int id = 0)
        {
            AcervoModel acervomodel = db.AcervoModels.Find(id);
            if (acervomodel == null)
            {
                return HttpNotFound();
            }
            return View(acervomodel);
        }

        //
        // GET: /Acervo/Create

        public ActionResult Create()
        {   
            //Carrega as viewBags 
            CarregaViewBagsCreate();

            return View();
        }

        //
        // POST: /Acervo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AcervoModel acervomodel)
        {
            if (ModelState.IsValid)
            {
                //Recura o tipo
                var tipo = db.TipoAcervoModels.Where(t => t.Id == acervomodel.TipoAcervoId).FirstOrDefault();

                //Recupera o autor
                var autor = db.AutoresModels.Where(a => a.Id == acervomodel.AutorId).FirstOrDefault();

                //Recupera a editora
                var editora = db.EditoraModels.Where(e => e.id == acervomodel.EditoraId).FirstOrDefault();

                //Associa para salvar no banco
                acervomodel.Tipo = tipo;
                acervomodel.Autor = autor;
                acervomodel.Editora = editora;

                //Salva no banco de dados
                db.AcervoModels.Add(acervomodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Carrega as viewBags caso não tenha conseguido gravar no banco de dados
            CarregaViewBagsCreate();

            //Retorna para a tela para que possam ser feitas as correções
            return View(acervomodel);
        }

        private void CarregaViewBagsCreate()
        {
            ViewBag.Tipos = new SelectList(db.TipoAcervoModels, "Id", "Descricao");
            ViewBag.Autores = new SelectList(db.AutoresModels, "Id", "Nome");
            ViewBag.Editoras = new SelectList(db.EditoraModels, "Id", "nome");

        }

        //
        // GET: /Acervo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AcervoModel acervomodel = db.AcervoModels.Find(id);
            if (acervomodel == null)
            {
                return HttpNotFound();
            }
            return View(acervomodel);
        }

        //
        // POST: /Acervo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AcervoModel acervomodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acervomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acervomodel);
        }

        //
        // GET: /Acervo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AcervoModel acervomodel = db.AcervoModels.Find(id);
            if (acervomodel == null)
            {
                return HttpNotFound();
            }
            return View(acervomodel);
        }

        //
        // POST: /Acervo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AcervoModel acervomodel = db.AcervoModels.Find(id);
            db.AcervoModels.Remove(acervomodel);
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