using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru

        DBKUTUPHANEEntities DbModel = new DBKUTUPHANEEntities();
        public ActionResult Duyuru()
        {
            var deger = DbModel.TBLDUYURULAR.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult YeniDuyuru()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDuyuru(TBLDUYURULAR prmt)
        {
            DbModel.TBLDUYURULAR.Add(prmt);
            DbModel.SaveChanges();
            return RedirectToAction("Duyuru");
        }

       
        public ActionResult DuyuruSil(int id)
        {
            var duyuru = DbModel.TBLDUYURULAR.Find(id);
            DbModel.TBLDUYURULAR.Remove(duyuru);
            DbModel.SaveChanges();
            return RedirectToAction("Duyuru");
        }

        public ActionResult DuyuruDetay(int id) 
        {
            var duyuru = DbModel.TBLDUYURULAR.Find(id);
            return View(duyuru);
        
        }

        [HttpPost]
        public ActionResult DuyuruGuncelle(TBLDUYURULAR prmt)
        {
            var duyuru = DbModel.TBLDUYURULAR.Find(prmt.DUYURUID);
            duyuru.ICERIK = prmt.ICERIK;
            duyuru.KATEGORI = prmt.KATEGORI;
            duyuru.TARIH = prmt.TARIH;
            DbModel.SaveChanges();
            return RedirectToAction("Duyuru");
        }
       
    }
}