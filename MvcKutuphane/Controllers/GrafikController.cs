using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models;



namespace MvcKutuphane.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Grafikler()
        {
            return View();
        }

        public ActionResult VisualizeKitapResult()
        {
            return Json(liste());
        }

        public List<Class1> liste()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                YayinEvi = "Güneş",
                sayi = 4
            });

            cs.Add(new Class1()
            {
                YayinEvi = "Mars",
                sayi = 3
            });

            cs.Add(new Class1()
            {
                YayinEvi = "Satürn",
                sayi = 3
            });
            return cs;

        }


    }
}