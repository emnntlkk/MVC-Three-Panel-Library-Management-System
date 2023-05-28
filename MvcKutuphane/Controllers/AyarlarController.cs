using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class AyarlarController : Controller
    {
        // GET: Ayarlar

        DBKUTUPHANEEntities DbModel = new DBKUTUPHANEEntities();
        public ActionResult ayarlar()
        {
            var kullanicilar = DbModel.TBLADMIN.ToList();
            return View(kullanicilar);
        }

        public ActionResult ayarlar2()
        {
            var kullanicilar = DbModel.TBLADMIN.ToList();
            return View(kullanicilar);
        }

        [HttpGet]
        public ActionResult YeniAdmin()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult YeniAdmin (TBLADMIN t)
        {
            DbModel.TBLADMIN.Add(t);
            DbModel.SaveChanges();
            return RedirectToAction("ayarlar2");
        }

        public ActionResult AdminSil(int id)
        {
            var admin = DbModel.TBLADMIN.Find(id);
            DbModel.TBLADMIN.Remove(admin);
            DbModel.SaveChanges();
            return RedirectToAction("ayarlar2");
        }

        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var admin = DbModel.TBLADMIN.Find(id);
            return View(admin);
        }

        [HttpPost]
        public ActionResult AdminGuncelle(TBLADMIN prmt)
        {
            var admin = DbModel.TBLADMIN.Find(prmt.ADMINID);
            admin.KULLANICI = prmt.KULLANICI;
            admin.SIFRE = prmt.SIFRE;
            admin.YETKI = prmt.YETKI;
            DbModel.SaveChanges();
            return RedirectToAction("ayarlar2");
        }


    }
}