using Odev3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odev3.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        DBModelEntities db = new DBModelEntities();
        public ActionResult Index(int? id)
        {
            var model = new DBModelEntities();
            model.Kategori = db.Kategori;
            model.AltKategori = db.AltKategori;
            model.Urunler = db.Urunler;
            ViewBag.Urunler = db.Urunler.Where(x => x.AltKategoriID == id).ToList();
            return View(model);
        }
    }
}