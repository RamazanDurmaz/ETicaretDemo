using Odev3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
namespace Odev3.Controllers
{
    public class AdminLoginController : Controller
    {
        DBModelEntities db = new DBModelEntities();
        // GET: AdminLogin
        public ActionResult Index()
        {
            
                return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminGiris([Bind(Include ="ID,KullaniciAdi,Sifre")] Admin adm)
        {
          
            if (ModelState.IsValid)
            {
                if(db.Admin.Any(x=>x.KullaniciAdi==adm.KullaniciAdi && x.Sifre == adm.Sifre))
                {
                    Session["Admin"] = adm.KullaniciAdi;
                  
                    return RedirectToAction("Index", "AdminUrunler");
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult AdminCikis()
        {
            Session["Admin"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}