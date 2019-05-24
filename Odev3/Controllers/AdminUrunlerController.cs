using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Odev3.Models;

namespace Odev3.Controllers
{
    public class AdminUrunlerController : Controller
    {
        private DBModelEntities db = new DBModelEntities();

        // GET: AdminUrunler
       
        public ActionResult Index()
        {
            if (Session["Admin"] == null) { return new HttpStatusCodeResult(HttpStatusCode.Unauthorized); }
            if(Session["Admin"].ToString()=="Seara") { }
            else { return new HttpStatusCodeResult(HttpStatusCode.Unauthorized); }
            var urunler = db.Urunler.Include(u => u.AltKategori);
            return View(urunler.ToList());
          
        }

        // GET: AdminUrunler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler urunler = db.Urunler.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }

        // GET: AdminUrunler/Create
        public ActionResult Create()
        {
            ViewBag.AltKategoriID = new SelectList(db.AltKategori, "ID", "AltKategoriAdi");
            return View();
        }

        // POST: AdminUrunler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UrunAdi,UrunResmi,Fiyati,StokMiktari,AltKategoriID")] Urunler urunler)
        {
            if (ModelState.IsValid)
            {
                db.Urunler.Add(urunler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AltKategoriID = new SelectList(db.AltKategori, "ID", "AltKategoriAdi", urunler.AltKategoriID);
            return View(urunler);
        }

        // GET: AdminUrunler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler urunler = db.Urunler.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            ViewBag.AltKategoriID = new SelectList(db.AltKategori, "ID", "AltKategoriAdi", urunler.AltKategoriID);
            return View(urunler);
        }

        // POST: AdminUrunler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UrunAdi,UrunResmi,Fiyati,StokMiktari,AltKategoriID")] Urunler urunler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urunler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AltKategoriID = new SelectList(db.AltKategori, "ID", "AltKategoriAdi", urunler.AltKategoriID);
            return View(urunler);
        }

        // GET: AdminUrunler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler urunler = db.Urunler.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }

        // POST: AdminUrunler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Urunler urunler = db.Urunler.Find(id);
            db.Urunler.Remove(urunler);
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
