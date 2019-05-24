using Odev3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odev3.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
      
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Mesajlar model)
        {
            try {
            DBModelEntities db = new DBModelEntities();
            Mesajlar emp = new Mesajlar();
            emp.KullaniciAdi = model.KullaniciAdi;
            emp.E_Posta = model.E_Posta;
            emp.Konu = model.Konu;
            emp.Mesaji = model.Mesaji;
            db.Mesajlar.Add(emp);
            db.SaveChanges();
            int latestEmpId = emp.ID;
            }catch(Exception ex)
            {
                throw ex;

            }
            return RedirectToAction("Index");
        }
      
       
    }
}