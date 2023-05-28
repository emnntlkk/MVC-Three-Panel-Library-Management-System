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
    public class KategoriController : Controller
    {

        DBKUTUPHANEEntities DbModel = new DBKUTUPHANEEntities();


        // GET: Kategori
      public ActionResult Index(string search, int ? page)
        {
            

            return View(DbModel.TBLKATEGORI.Where(x => (x.AD.Contains(search) || search == null) && x.DURUM==true).ToList().ToPagedList(page ?? 1, 8));
        }
  
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult KategoriEkle(TBLKATEGORI p)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            DbModel.TBLKATEGORI.Add(p);
            DbModel.SaveChanges();
            return View();
        }

        public ActionResult KategoriSil (int id)
        { 
            var kategori = DbModel.TBLKATEGORI.Find(id);
            //DbModel.TBLKATEGORI.Remove(kategori);
            //DbModel.SaveChanges();
            kategori.DURUM = false;
            DbModel.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int? id=null)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriGetir");
            }
            var ktg = DbModel.TBLKATEGORI.Find(id);
            return View(ktg);
        }

       
        public ActionResult KategoriGuncelle (TBLKATEGORI prmt)
        {
            var ktg = DbModel.TBLKATEGORI.Find(prmt.KATEGORIID);
            ktg.AD = prmt.AD;
            DbModel.SaveChanges();
            return RedirectToAction("Index");

        }



    }
}