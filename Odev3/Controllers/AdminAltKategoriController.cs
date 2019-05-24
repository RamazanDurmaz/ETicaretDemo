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
    public class AdminAltKategoriController : Controller
    {
        private DBModelEntities db = new DBModelEntities();

        // GET: AdminAltKategori
        public ActionResult Index()
        {
            var altKategori = db.AltKategori.Include(a => a.Kategori);
            return View(altKategori.ToList());
        }

        // GET: AdminAltKategori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AltKategori altKategori = db.AltKategori.Find(id);
            if (altKategori == null)
            {
                return HttpNotFound();
            }
            return View(altKategori);
        }

        // GET: AdminAltKategori/Create
        public ActionResult Create()
        {
            ViewBag.KategoriID = new SelectList(db.Kategori, "ID", "KategoriAdi");
            return View();
        }

        // POST: AdminAltKategori/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AltKategoriAdi,KategoriID")] AltKategori altKategori)
        {
            if (ModelState.IsValid)
            {
                db.AltKategori.Add(altKategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriID = new SelectList(db.Kategori, "ID", "KategoriAdi", altKategori.KategoriID);
            return View(altKategori);
        }

        // GET: AdminAltKategori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AltKategori altKategori = db.AltKategori.Find(id);
            if (altKategori == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriID = new SelectList(db.Kategori, "ID", "KategoriAdi", altKategori.KategoriID);
            return View(altKategori);
        }

        // POST: AdminAltKategori/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AltKategoriAdi,KategoriID")] AltKategori altKategori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(altKategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriID = new SelectList(db.Kategori, "ID", "KategoriAdi", altKategori.KategoriID);
            return View(altKategori);
        }

        // GET: AdminAltKategori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AltKategori altKategori = db.AltKategori.Find(id);
            if (altKategori == null)
            {
                return HttpNotFound();
            }
            return View(altKategori);
        }

        // POST: AdminAltKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AltKategori altKategori = db.AltKategori.Find(id);
            db.AltKategori.Remove(altKategori);
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
