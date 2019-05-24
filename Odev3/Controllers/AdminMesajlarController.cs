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
    public class AdminMesajlarController : Controller
    {
        private DBModelEntities db = new DBModelEntities();

        // GET: AdminMesajlar
        public ActionResult Index()
        {
            return View(db.Mesajlar.ToList());
        }

        // GET: AdminMesajlar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesajlar mesajlar = db.Mesajlar.Find(id);
            if (mesajlar == null)
            {
                return HttpNotFound();
            }
            return View(mesajlar);
        }

        // GET: AdminMesajlar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminMesajlar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,KullaniciAdi,Mesaji,Konu,E_Posta")] Mesajlar mesajlar)
        {
            if (ModelState.IsValid)
            {
                db.Mesajlar.Add(mesajlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mesajlar);
        }

        // GET: AdminMesajlar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesajlar mesajlar = db.Mesajlar.Find(id);
            if (mesajlar == null)
            {
                return HttpNotFound();
            }
            return View(mesajlar);
        }

        // POST: AdminMesajlar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,KullaniciAdi,Mesaji,Konu,E_Posta")] Mesajlar mesajlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mesajlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mesajlar);
        }

        // GET: AdminMesajlar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesajlar mesajlar = db.Mesajlar.Find(id);
            if (mesajlar == null)
            {
                return HttpNotFound();
            }
            return View(mesajlar);
        }

        // POST: AdminMesajlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mesajlar mesajlar = db.Mesajlar.Find(id);
            db.Mesajlar.Remove(mesajlar);
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
