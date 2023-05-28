using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar

        DBKUTUPHANEEntities DbModel = new DBKUTUPHANEEntities();
        public ActionResult GelenMesajlar()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = DbModel.TBLMESAJLAR.Where(x => x.ALICI == uyemail.ToString()).ToList();
            
            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = DbModel.TBLMESAJLAR.Where(x => x.GONDEREN == uyemail.ToString()).ToList();

            return View(mesajlar);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJLAR mesaj)
        {
            var uyemail = (string)Session["Mail"].ToString();
            mesaj.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            mesaj.GONDEREN = uyemail.ToString();
            DbModel.TBLMESAJLAR.Add(mesaj);
            DbModel.SaveChanges();
            return RedirectToAction("GidenMesajlar");
        }

        public PartialViewResult Partial1()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var gelensayisi = DbModel.TBLMESAJLAR.Where(x => x.ALICI == uyemail).Count();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = DbModel.TBLMESAJLAR.Where(x => x.GONDEREN == uyemail).Count();
            ViewBag.d2 = gidensayisi;
            return PartialView();
        }
    }
}