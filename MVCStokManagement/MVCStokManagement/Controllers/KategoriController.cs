using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokManagement.Models.Entity;

namespace MVCStokManagement.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        MVCStokDBEntities db = new MVCStokDBEntities();
        public ActionResult KategoriIndex()
        {
            var degerler = db.TBLKATEGORILER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategoriEkle(TBLKATEGORILER k1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniKategoriEkle");
            }
            db.TBLKATEGORILER.Add(k1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var kategori = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("KategoriIndex");
        }
        [HttpGet]
        public ActionResult KategoriGuncelle(int id)
        {
            var kategori = db.TBLKATEGORILER.Find(id);
            return View("KategoriGuncelle", kategori);
        }

        [HttpPost]
        public ActionResult KategoriGuncelle(TBLKATEGORILER k1)
        {
            var kategori = db.TBLKATEGORILER.Find(k1.KategoriID);
            kategori.KategoriAD = k1.KategoriAD;
            db.SaveChanges();
            return RedirectToAction("KategoriIndex");
        }
    }
}