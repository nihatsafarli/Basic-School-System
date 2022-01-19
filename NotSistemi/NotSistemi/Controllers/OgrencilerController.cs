using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotSistemi.Models.EntityFramework;

namespace NotSistemi.Controllers
{
    public class OgrencilerController : Controller
    {
        // GET: Ogrenciler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {

            var ogrenciler = db.TBL_OGRENCILER.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TBL_KULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(TBL_OGRENCILER p3)
        {
            var klp = db.TBL_KULUPLER.Where(m => m.KULUPID == p3.TBL_KULUPLER.KULUPID).FirstOrDefault();
            p3.TBL_KULUPLER = klp;
            db.TBL_OGRENCILER.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBL_OGRENCILER.Find(id);
            db.TBL_OGRENCILER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.TBL_OGRENCILER.Find(id);

            List<SelectListItem> degerler = (from i in db.TBL_KULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("OgrenciGetir", ogrenci);
        }
        public ActionResult Guncelle(TBL_OGRENCILER p)
        {
            var ogr = db.TBL_OGRENCILER.Find(p.OGRENCIID);
            ogr.OGRAD = p.OGRAD;
            ogr.OGRSOYAD = p.OGRSOYAD;
            ogr.OGRFOTOGRAF = p.OGRFOTOGRAF;
            ogr.OGRCINSIYET = p.OGRCINSIYET;
            ogr.OGRKULUP = p.OGRKULUP;
            db.SaveChanges();

            return RedirectToAction("Index", "Ogrenciler");
        }
    }
}

//List<SelectListItem> items = new List<SelectListItem>();

//items.Add(new SelectListItem { Text = "Matematik", Value = "0" });

//items.Add(new SelectListItem { Text = "Fizik", Value = "1" });

//items.Add(new SelectListItem { Text = "Kimya", Value = "2", });

//items.Add(new SelectListItem { Text = "Biyoloji", Value = "3" });

//items.Add(new SelectListItem { Text = "Coğrafya", Value = "3" });

//ViewBag.DersAd = items;