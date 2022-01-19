using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NotSistemi.Controllers
{
    public class HesapMakinesiController : Controller
    {
        // GET: HesapMakinesi
        public ActionResult Index(int Sayi1 = 0, int Sayi2 = 0)
        {
            int sonuc = Sayi1 + Sayi2;
            ViewBag.snc = sonuc;
            return View();
        }
    }
}