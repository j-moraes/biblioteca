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
    public class GerenciamentoAcervoController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /GerenciamentoAcervo/

        public ActionResult Index()
        {
            return View(db.GerenciamentoAcervoModels.ToList());
        }

        //
        // GET: /GerenciamentoAcervo/Details/5

        public ActionResult Details(int id = 0)
        {
            GerenciamentoAcervoModel gerenciamentoacervomodel = db.GerenciamentoAcervoModels.Find(id);
            if (gerenciamentoacervomodel == null)
            {
                return HttpNotFound();
            }
            return View(gerenciamentoacervomodel);
        }

        //
        // GET: /GerenciamentoAcervo/Create

        public ActionResult Create()
        {
            //  var usuario = new UsuarioModel();
            CarregaViewBagsCreate();
            return View();

        }
        //-----------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GerenciamentoAcervoModel gerenciamentoacervomodel)
        {
            if (ModelState.IsValid)
            {
                //Recura o tipo


                //Recupera o autor
                var usuario = db.UsuarioModels.Where(a => a.Id == gerenciamentoacervomodel.usuarioId).FirstOrDefault();


                //Associa para salvar no banco
                gerenciamentoacervomodel.usuario = usuario;

                //Salva no banco de dados
                db.GerenciamentoAcervoModels.Add(gerenciamentoacervomodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Carrega as viewBags caso não tenha conseguido gravar no banco de dados
            CarregaViewBagsCreate();

            //Retorna para a tela para que possam ser feitas as correções
            return View(gerenciamentoacervomodel);
        }

        private void CarregaViewBagsCreate()
        {
            ViewBag.Usuarios = new SelectList(db.UsuarioModels.Where(u => u.Ativo).ToList(), "Id", "Nome");
            //  var acervo = new AcervoModel();
            ViewBag.Acervos = new SelectList(db.AcervoModels, "Id", "Descricao");

        }
        //------------------------------------------
        //
        // POST: /GerenciamentoAcervo/Create

        

        //
        // GET: /GerenciamentoAcervo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            GerenciamentoAcervoModel gerenciamentoacervomodel = db.GerenciamentoAcervoModels.Find(id);
            if (gerenciamentoacervomodel == null)
            {
                return HttpNotFound();
            }
            return View(gerenciamentoacervomodel);
        }

        //
        // POST: /GerenciamentoAcervo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GerenciamentoAcervoModel gerenciamentoacervomodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gerenciamentoacervomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gerenciamentoacervomodel);
        }

        //
        // GET: /GerenciamentoAcervo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            GerenciamentoAcervoModel gerenciamentoacervomodel = db.GerenciamentoAcervoModels.Find(id);
            if (gerenciamentoacervomodel == null)
            {
                return HttpNotFound();
            }
            return View(gerenciamentoacervomodel);
        }

        //
        // POST: /GerenciamentoAcervo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GerenciamentoAcervoModel gerenciamentoacervomodel = db.GerenciamentoAcervoModels.Find(id);
            db.GerenciamentoAcervoModels.Remove(gerenciamentoacervomodel);
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