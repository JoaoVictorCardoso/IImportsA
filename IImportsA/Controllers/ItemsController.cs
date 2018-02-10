using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IImportsA.Models;

namespace IImportsA.Controllers
{
    public class ItemsController : Controller
    {
        private IImportsAContext db = new IImportsAContext();

        // GET: Items
        public async Task<ActionResult> Index()
        {
            return View(await db.Items.ToListAsync());
        }

        


        public async Task<ActionResult> Produto(string busca)
        {
            var produto = from dados in db.Items select dados;
            if (!String.IsNullOrEmpty(busca))
            {
                produto = produto.Where(
                    item => item.Imagem.Contains(busca) ||
                    item.Preco.ToString().Contains(busca) ||
                    item.Referencia.Contains(busca) ||
                    item.QuantidadeTotal.ToString().Contains(busca)
                    );
            }
            return View(await produto.ToListAsync());
        }

        public async Task<ActionResult> UDetalhe(int? id)
        {
            if (id == null) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Referencia,QuantidadeTotal,Preco,Descricao,Imagem,Cor_1,Quantidade_Cor_1,Cor_2,Quantidade_Cor_2,Cor_3,Quantidade_Cor_3,Cor_4,Quantidade_Cor_4,Cor_5,Quantidade_Cor_5,Cor_6,Quantidade_Cor_6,Cor_7,Quantidade_Cor_7,Cor_8,Quantidade_Cor_8,Cor_9,Quantidade_Cor_9,Cor_10,Quantidade_Cor_10,Cor_11,Quantidade_Cor_11,Cor_12,Quantidade_Cor_12,Cor_13,Quantidade_Cor_13,Cor_14,Quantidade_Cor_14,Cor_15,Quantidade_Cor_15,Cor_16,Quantidade_Cor_16,Cor_17,Quantidade_Cor_17,Cor_18,Quantidade_Cor_18,Cor_19,Quantidade_Cor_19,Cor_20,Quantidade_Cor_20,Tamanho_1,Tamanho_2,Tamanho_3,Tamanho_4,Tamanho_5,Tamanho_6,Tamanho_7,Tamanho_8,Tamanho_9,Tamanho_10")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Referencia,QuantidadeTotal,Preco,Descricao,Imagem,Cor_1,Quantidade_Cor_1,Cor_2,Quantidade_Cor_2,Cor_3,Quantidade_Cor_3,Cor_4,Quantidade_Cor_4,Cor_5,Quantidade_Cor_5,Cor_6,Quantidade_Cor_6,Cor_7,Quantidade_Cor_7,Cor_8,Quantidade_Cor_8,Cor_9,Quantidade_Cor_9,Cor_10,Quantidade_Cor_10,Cor_11,Quantidade_Cor_11,Cor_12,Quantidade_Cor_12,Cor_13,Quantidade_Cor_13,Cor_14,Quantidade_Cor_14,Cor_15,Quantidade_Cor_15,Cor_16,Quantidade_Cor_16,Cor_17,Quantidade_Cor_17,Cor_18,Quantidade_Cor_18,Cor_19,Quantidade_Cor_19,Cor_20,Quantidade_Cor_20,Tamanho_1,Tamanho_2,Tamanho_3,Tamanho_4,Tamanho_5,Tamanho_6,Tamanho_7,Tamanho_8,Tamanho_9,Tamanho_10")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Item item = await db.Items.FindAsync(id);
            db.Items.Remove(item);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
