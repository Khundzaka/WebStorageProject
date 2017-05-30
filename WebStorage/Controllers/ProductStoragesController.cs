using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebStorage.Models;

namespace WebStorage.Controllers
{
    public class ProductStoragesController : Controller
    {
        private WebStorageContext db = new WebStorageContext();

        // GET: ProductStorages
        public ActionResult Index()
        {
            var productStorages = db.ProductStorages.Include(p => p.Product).Include(p => p.Storage);
            return View(productStorages.ToList());
        }

        // GET: ProductStorages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductStorage productStorage = db.ProductStorages.Find(id);
            if (productStorage == null)
            {
                return HttpNotFound();
            }
            return View(productStorage);
        }

        // GET: ProductStorages/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Title");
            ViewBag.StorageId = new SelectList(db.Storages, "StorageId", "Title");
            return View();
        }

        // POST: ProductStorages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductStorageId,ProductId,StorageId,Quantity")] ProductStorage productStorage)
        {
            if (ModelState.IsValid)
            {
                db.ProductStorages.Add(productStorage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Title", productStorage.ProductId);
            ViewBag.StorageId = new SelectList(db.Storages, "StorageId", "Title", productStorage.StorageId);
            return View(productStorage);
        }

        // GET: ProductStorages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductStorage productStorage = db.ProductStorages.Find(id);
            if (productStorage == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Title", productStorage.ProductId);
            ViewBag.StorageId = new SelectList(db.Storages, "StorageId", "Title", productStorage.StorageId);
            return View(productStorage);
        }

        // POST: ProductStorages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductStorageId,ProductId,StorageId,Quantity")] ProductStorage productStorage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productStorage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Title", productStorage.ProductId);
            ViewBag.StorageId = new SelectList(db.Storages, "StorageId", "Title", productStorage.StorageId);
            return View(productStorage);
        }

        // GET: ProductStorages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductStorage productStorage = db.ProductStorages.Find(id);
            if (productStorage == null)
            {
                return HttpNotFound();
            }
            return View(productStorage);
        }

        // POST: ProductStorages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductStorage productStorage = db.ProductStorages.Find(id);
            db.ProductStorages.Remove(productStorage);
            db.SaveChanges();
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
