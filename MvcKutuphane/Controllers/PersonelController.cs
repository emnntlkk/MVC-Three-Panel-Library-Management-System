using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class PersonelController : Controller
    {

        DBKUTUPHANEEntities dbModel = new DBKUTUPHANEEntities();
        // GET: Personel
        public ActionResult PersonelListele(string search, int? page)
        {
            return View(dbModel.TBLPERSONEL.Where(x => x.PERSONEL.Contains(search) || search == null).ToList().ToPagedList(page ?? 1, 8));
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(TBLPERSONEL prs)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            dbModel.TBLPERSONEL.Add(prs);
            dbModel.SaveChanges();
            return View();
        }

        public ActionResult PersonelSil(int id)
        {
            var person = dbModel.TBLPERSONEL.Find(id);
            dbModel.TBLPERSONEL.Remove(person);
            dbModel.SaveChanges();
            return RedirectToAction("PersonelListele");
        }

        public ActionResult PersonelGetir(int id)
        {
            var prs = dbModel.TBLPERSONEL.Find(id);
            return View(prs);
        }

        public ActionResult PersonelGuncelle(TBLPERSONEL p)
        {
            var prs = dbModel.TBLPERSONEL.Find(p.PERSONELID);
            prs.PERSONEL = p.PERSONEL;
            dbModel.SaveChanges();
            return RedirectToAction("PersonelListele");
        }






    }
}