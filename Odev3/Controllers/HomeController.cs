using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Odev3.Models;
using System.Globalization;

namespace Odev3.Controllers
{
    public class HomeController : Controller
    {
       private DBModelEntities db = new DBModelEntities();
        public ActionResult Index(int? id)
        {
           
            var model = new DBModelEntities();
            model.Kategori = db.Kategori;
            model.AltKategori = db.AltKategori;
            model.Urunler = db.Urunler;
            ViewBag.Urunler = db.Urunler.Where(x => x.AltKategoriID == id).ToList();



            return View(model);

         }

     
        
      
        public ActionResult Detay(int? id)
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
       
        public ActionResult SatinAlma()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult SatinAl(Satis model)
        {
            try
            {
                DBModelEntities db = new DBModelEntities();
                Satis emp = new Satis();
                emp.MusteriAdi = model.MusteriAdi;
                emp.E_Posta = model.E_Posta;
                emp.MusteriSoyadi = model.MusteriSoyadi;
                emp.Adres1 = model.Adres1;
                emp.Adres2 = model.Adres2;
                emp.PostaKodu = model.PostaKodu;
                emp.Tarih = model.Tarih;
                emp.Telefon = model.Telefon;
                db.Satis.Add(emp);
                db.SaveChanges();
                int latestEmpId = emp.ID;
                ViewBag.Message = "Satın Alındı";
            }
            catch (Exception ex)
            {
                throw ex;

            }

            return RedirectToAction("SatinAlma");
        }
        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }

    }
}