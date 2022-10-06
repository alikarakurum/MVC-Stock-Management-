using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokManagement.Models.Entity;

namespace MVCStokManagement.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri

        MVCStokDBEntities db = new MVCStokDBEntities();
        public ActionResult MusteriIndex()
        {
            var musteriler = db.TBLMUSTERILER.ToList();
            return View(musteriler);
        }

        [HttpGet]
        public ActionResult YeniMusteriEkle()
        {
            return View();
        }
         
        [HttpPost]
        public ActionResult YeniMusteriEkle(TBLMUSTERILER m1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniMusteriEkle");
            }
            db.TBLMUSTERILER.Add(m1);
            db.SaveChanges();
            return RedirectToAction("MusteriIndex");
        }

        public ActionResult Sil(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("MusteriIndex");
        }

        [HttpGet]
        public ActionResult MusteriGuncelle(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            return View("MusteriGuncelle", musteri);

        }

        [HttpPost]
        public ActionResult MusteriGuncelle(TBLMUSTERILER m1)
        {
            var musteri = db.TBLMUSTERILER.Find(m1.MusteriID);
            musteri.MusteriAD = m1.MusteriAD;
            musteri.MusteriSOYAD = m1.MusteriSOYAD;
            db.SaveChanges();
            return RedirectToAction("MusteriIndex");
        }
    }
}