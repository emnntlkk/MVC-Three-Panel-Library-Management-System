using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class OduncController : Controller
    {

        DBKUTUPHANEEntities dbModel = new DBKUTUPHANEEntities();
        // GET: Odunc

        [Authorize(Roles ="A")]
        public ActionResult OduncAl()
        {
            var degerler = dbModel.TBLHAREKET.Where(x => x.ISLEMDURUM == false).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from x in dbModel.TBLUYELER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UYEID +"| " + x.AD +" "+x.SOYAD,
                                               Value = x.UYEID.ToString()
                                               
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in dbModel.TBLKITAP.Where(y=>y.DURUM==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KITAPAD,
                                               Value = x.KITAPID.ToString()

                                           }).ToList();

            List<SelectListItem> deger3 = (from x in dbModel.TBLPERSONEL.ToList()
                                           select new SelectListItem
                                           {
                                               Text =x.PERSONELID +"| "+ x.PERSONEL,
                                               Value = x.PERSONELID.ToString()
                                           }).ToList();

            ViewBag.deger1 = deger1;
            ViewBag.deger2 = deger2;
            ViewBag.deger3 = deger3;
            return View();
        }

        [HttpPost]
        public ActionResult Oduncver(TBLHAREKET prmt)
        {
            var d1 = dbModel.TBLUYELER.Where(x => x.UYEID == prmt.TBLUYELER.UYEID).FirstOrDefault();

            var d2 = dbModel.TBLKITAP.Where(x => x.KITAPID == prmt.TBLKITAP.KITAPID).FirstOrDefault();

            var d3 = dbModel.TBLPERSONEL.Where(x => x.PERSONELID == prmt.TBLPERSONEL.PERSONELID).FirstOrDefault();

            
            prmt.TBLUYELER = d1;
            prmt.TBLKITAP = d2;
            prmt.TBLPERSONEL = d3;
            dbModel.TBLHAREKET.Add(prmt);
            dbModel.SaveChanges();
            return RedirectToAction("OduncAl");
        }

        public ActionResult OduncIade(int id)
        {
            var deger = dbModel.TBLHAREKET.Find(id);
            DateTime d1 = Convert.ToDateTime(deger.IADETARIH.ToString());
            DateTime d2=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3=d2-d1;
            ViewBag.dgr=d3.TotalDays;
            
            return View(deger);
        }

        public ActionResult OduncGuncelle(TBLHAREKET prmt)
        {
            var hrk = dbModel.TBLHAREKET.Find(prmt.HAREKETID);
            hrk.UYEGETIRTARIH = prmt.UYEGETIRTARIH;
            hrk.ISLEMDURUM = true;
           dbModel.SaveChanges();
            return RedirectToAction("OduncAl");
        }
    }
}