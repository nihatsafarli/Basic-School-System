using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotSistemi.Models.EntityFramework;

namespace NotSistemi.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var kulupler = db.TBL_KULUPLER.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKulup(TBL_KULUPLER p2)
        {
            db.TBL_KULUPLER.Add(p2);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kulup = db.TBL_KULUPLER.Find(id);
            db.TBL_KULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupGetir(int id)
        {
            var kulup2 = db.TBL_KULUPLER.Find(id);         
            return View("KulupGetir",kulup2);
        }
        public ActionResult Guncelle(TBL_KULUPLER p)
        {
            var klp = db.TBL_KULUPLER.Find(p.KULUPID);
            klp.KULUPAD = p.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulupler");

        }
    }
}