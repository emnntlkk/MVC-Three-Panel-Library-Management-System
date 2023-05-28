using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar

        DBKUTUPHANEEntities DbModel = new DBKUTUPHANEEntities();
        public ActionResult YazarListele(string search, int? page)
        {
            return View(DbModel.TBLYAZAR.Where(x => x.AD.Contains(search) || search == null).ToList().ToPagedList(page ?? 1,8));
          
        }

       


        public ActionResult YazarSil(int id)
        {
            var yazar = DbModel.TBLYAZAR.Find(id);
            DbModel.TBLYAZAR.Remove(yazar);
            DbModel.SaveChanges();
            return RedirectToAction("YazarListele");
        }

        [HttpGet]
        public ActionResult YazarEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult YazarEkle(TBLYAZAR yazar)
        {
            if (!ModelState.IsValid) 
            {
                return View ("YazarEkle");
            }
            DbModel.TBLYAZAR.Add(yazar);
            DbModel.SaveChanges();
            return RedirectToAction("YazarListele");

        }

        public ActionResult YazarGetir(int id)
        {
            var yazar = DbModel.TBLYAZAR.Find(id);
            return View(yazar);
        }

        public ActionResult YazarGuncelle(TBLYAZAR yzrData)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            var yazar = DbModel.TBLYAZAR.Find(yzrData.YAZARID);
            yazar.AD = yzrData.AD;
            yazar.SOYAD = yzrData.SOYAD;
            yazar.DETAY = yzrData.DETAY;
            DbModel.SaveChanges();
            return RedirectToAction("YazarListele");
        }

        public ActionResult YazarKitaplar(int id)
        {
            var yazar = DbModel.TBLKITAP.Where(x => x.YAZAR == id).ToList();
            var yzrAdSoyad = DbModel.TBLYAZAR.Where(y => y.YAZARID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();

            ViewBag.yazar = yzrAdSoyad;
            return View(yazar);
        }










    }
}