using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MvcKutuphane.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye

        DBKUTUPHANEEntities dbModel = new DBKUTUPHANEEntities();
        public ActionResult UyeListele(int sayfa=1)
        {

            // var degerler = dbModel.TBLUYELER.ToList();
            var degerler = dbModel.TBLUYELER.ToList().ToPagedList(sayfa,3);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(TBLUYELER uye)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            dbModel.TBLUYELER.Add(uye);
            dbModel.SaveChanges();
            return RedirectToAction("UyeListele");
        }

        public ActionResult UyeSil(int id)
        {
            var uye = dbModel.TBLUYELER.Find(id);
            dbModel.TBLUYELER.Remove(uye);
            dbModel.SaveChanges();
            return RedirectToAction("UyeListele");
        }

        public ActionResult UyeGetir(int id)
        {
            var uye = dbModel.TBLUYELER.Find(id);
            return View(uye);
        }

        

        public ActionResult UyeGuncelle(TBLUYELER prmt)
        {
            var uye = dbModel.TBLUYELER.Find(prmt.UYEID);
            uye.AD = prmt.AD;
            uye.SOYAD = prmt.SOYAD;
            uye.MAIL = prmt.MAIL;
            uye.KULLANICIADI = prmt.KULLANICIADI;
            uye.SIFRE = prmt.SIFRE;
            uye.OKUL = prmt.OKUL;
            uye.TELEFON = prmt.TELEFON;
            uye.FOTOGRAF = prmt.FOTOGRAF;
            dbModel.SaveChanges();
            return RedirectToAction("UyeListele");

        }

        public ActionResult UyeKitapGecmis(int id)
        {
            var ktpgcms = dbModel.TBLHAREKET.Where(x => x.UYE == id).ToList();
            var uyeAdSoyad = dbModel.TBLUYELER.Where(y => y.UYEID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
            ViewBag.uyeAdSoyad = uyeAdSoyad;
            return View(ktpgcms);
        }
    }
}