using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokManagement.Models.Entity;
namespace MVCStokManagement.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MVCStokDBEntities db = new MVCStokDBEntities();
        public ActionResult UrunIndex()
        {
            var urunler = db.TBLURUNLER.ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult YeniUrunEkle()
        {

            List<SelectListItem> kategoriler = (from i in db.TBLKATEGORILER.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.KategoriAD,
                                                    Value = i.KategoriID.ToString()
                                                }).ToList();
            ViewBag.ktgrlr = kategoriler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrunEkle(TBLURUNLER u1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniUrunEkle");
            }
            var ktg = db.TBLKATEGORILER.Where(m => m.KategoriID == u1.TBLKATEGORILER.KategoriID).FirstOrDefault();
            u1.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(u1);
            db.SaveChanges();
            return RedirectToAction("YeniUrunEkle");
        }

        public ActionResult Sil(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("UrunIndex");
        }

        [HttpGet]
        public ActionResult UrunGuncelle(int id)
        {
            List<SelectListItem> kategoriler = (from i in db.TBLKATEGORILER.ToList() select new SelectListItem { Text = i.KategoriAD, Value = i.KategoriID.ToString() }).ToList();
            ViewBag.ktgrlr = kategoriler;
            var urun = db.TBLURUNLER.Find(id);
            return View("UrunGuncelle", urun);
        }
        [HttpPost]
        public ActionResult UrunGuncelle(TBLURUNLER u1)
        {
            var urun = db.TBLURUNLER.Find(u1.UrunID);
            var ktg = db.TBLKATEGORILER.Where(m => m.KategoriID == u1.TBLKATEGORILER.KategoriID).FirstOrDefault();
            urun.UrunID = u1.UrunID;
            urun.UrunAD = u1.UrunAD;
            urun.UrunMARKA = u1.UrunMARKA;
            urun.TBLKATEGORILER = ktg;
            urun.UrunFIYAT = u1.UrunFIYAT;
            urun.UrunSTOK = u1.UrunSTOK;
            db.SaveChanges();
            return RedirectToAction("UrunIndex");
        }
    }
}