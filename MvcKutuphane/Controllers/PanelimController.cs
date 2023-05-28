using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    
    public class PanelimController : Controller
    {
        // GET: Panelim

        DBKUTUPHANEEntities DbModel = new DBKUTUPHANEEntities();

        [HttpGet]
        
        public ActionResult Panel()
        {
            var uyeMail = (string)Session["Mail"];
            //var degerler = DbModel.TBLUYELER.FirstOrDefault(z => z.MAIL == uyeMail);
            var degerler = DbModel.TBLDUYURULAR.ToList();
            var d1 = DbModel.TBLUYELER.Where(x => x.MAIL == uyeMail).Select(y => y.AD).FirstOrDefault();
            ViewBag.d1 = d1;
            var d2 = DbModel.TBLUYELER.Where(x => x.MAIL == uyeMail).Select(y => y.SOYAD).FirstOrDefault();
            ViewBag.d2 = d2;

            var d3 = DbModel.TBLUYELER.Where(x => x.MAIL == uyeMail).Select(y => y.FOTOGRAF).FirstOrDefault();
            ViewBag.d3 = d3;

            var d4 = DbModel.TBLUYELER.Where(x => x.MAIL == uyeMail).Select(y => y.KULLANICIADI).FirstOrDefault();
            ViewBag.d4 = d4;

            var d5 = DbModel.TBLUYELER.Where(x => x.MAIL == uyeMail).Select(y => y.OKUL).FirstOrDefault();
            ViewBag.d5 = d5;

            var d6 = DbModel.TBLUYELER.Where(x => x.MAIL == uyeMail).Select(y => y.TELEFON).FirstOrDefault();
            ViewBag.d6 = d6;

            var d7 = DbModel.TBLUYELER.Where(x => x.MAIL == uyeMail).Select(y => y.MAIL).FirstOrDefault();
            ViewBag.d7 = d7;

            int uyeid = DbModel.TBLUYELER.Where(x => x.MAIL == uyeMail).Select(y => y.UYEID).FirstOrDefault();

            var d8 = DbModel.TBLHAREKET.Where(x => x.UYE == uyeid).Count();
            ViewBag.d8 = d8;

            var d9 = DbModel.TBLMESAJLAR.Where(x => x.ALICI == uyeMail).Count();
            ViewBag.d9 = d9;

            var d10 = DbModel.TBLDUYURULAR.Count();
            ViewBag.d10 = d10;
            return View(degerler);
            
        }


        [HttpPost]
        public ActionResult Panel(TBLUYELER prmt)
        {
            var mail = (string)Session["Mail"];
            var uye = DbModel.TBLUYELER.FirstOrDefault(x => x.MAIL == mail);
            uye.SIFRE = prmt.SIFRE;
            uye.FOTOGRAF = prmt.FOTOGRAF;
            uye.KULLANICIADI = prmt.KULLANICIADI;
            DbModel.SaveChanges();
            return RedirectToAction("Panel");
        }

        public ActionResult Kitaplarim()
        {
            var mail = (string)Session["Mail"];
            var id = DbModel.TBLUYELER.Where(x => x.MAIL == mail.ToString()).Select(z => z.UYEID).FirstOrDefault();
            var degerler = DbModel.TBLHAREKET.Where(x => x.UYE == id).ToList();
            return View(degerler);
        }

        
        public ActionResult Duyurular()
        {
            var duyurulistesi = DbModel.TBLDUYURULAR.ToList();
            return View(duyurulistesi);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap","Login");
        }

        public PartialViewResult Partial1 ()
        {
            return PartialView("Partial1");
        }

        public PartialViewResult Partial2()
        {
            var uyeMail = (string)Session["Mail"];
            var id = DbModel.TBLUYELER.Where(x => x.MAIL == uyeMail).Select(y => y.UYEID).FirstOrDefault();
            var uyeBul = DbModel.TBLUYELER.Find(id);

            return PartialView("Partial2",uyeBul);
        }

    }
}