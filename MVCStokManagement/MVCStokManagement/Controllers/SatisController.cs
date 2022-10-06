using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokManagement.Models.Entity;

namespace MVCStokManagement.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MVCStokDBEntities db = new MVCStokDBEntities();
        public ActionResult SatisIndex()
        {
            var satislar = db.TBLSATISLAR.ToList();
            return View(satislar);
        }

        [HttpGet]
        public ActionResult YeniSatisEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatisEkle(TBLSATISLAR s1)
        {
            db.TBLSATISLAR.Add(s1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var satis = db.TBLSATISLAR.Find(id);
            db.TBLSATISLAR.Remove(satis);
            db.SaveChanges();
            return RedirectToAction("SatisIndex");
        }
       
    }
}