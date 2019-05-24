using Odev3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odev3.Controllers
{
    public class UyelerController : Controller
    {
        // GET: Uyeler
        DBModelEntities db = new DBModelEntities();
        public ActionResult KayitOl()
        {
            return View();
        }

        public ActionResult UyeGiris()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult UyeOl(Uyeler uye)
        {
            using(DBModelEntities dbModel = new DBModelEntities())
            {
                
                dbModel.Uyeler.Add(uye);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful";


            return RedirectToAction("KayitOl",new Uyeler());
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UyeGiris([Bind(Include = "ID,KullaniciAdi,Sifre")] Uyeler uye)
        {

            if (ModelState.IsValid)
            {
                if (db.Uyeler.Any(x => x.KullaniciAdi == uye.KullaniciAdi && x.Sifre == uye.Sifre))
                {
                    Session["KullaniciAdi"] = uye.KullaniciAdi;
                    return RedirectToAction("Index","Home");
                }
            }

            return RedirectToAction("KayitOl");
        }

        public ActionResult Cikis()
        {
            Session["KullaniciAdi"] = null;
            return RedirectToAction("Index","Home");
        }
    }
}