using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class IstatistikController : Controller
    {
        DBKUTUPHANEEntities dbModel = new DBKUTUPHANEEntities();
        // GET: Istatistik
        public ActionResult Index()
        {
            var deger1 = dbModel.TBLUYELER.Count();
            var deger2 = dbModel.TBLKITAP.Count();
            var deger3 = dbModel.TBLKITAP.Where(x => x.DURUM == false).Count();
            var deger4 = dbModel.TBLCEZALAR.Sum(x => x.PARA);
            ViewBag.toplamUye = deger1;
            ViewBag.toplamKitap = deger2;
            ViewBag.falseKitap = deger3;
            ViewBag.KasaToplam = deger4;
            return View();
        }

        public ActionResult havaDurumu()
        {
            return View();
        }

        public ActionResult HavaKartlari()
        {
            return View();
        }

        public ActionResult Galeri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult resimYukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyaYolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));

                dosya.SaveAs(dosyaYolu);

            }

            return RedirectToAction("Galeri");
        }

        public ActionResult linqKartlari()
        {
            var deger1 = dbModel.TBLKITAP.Count();
            var deger2 = dbModel.TBLUYELER.Count();
            var deger3 = dbModel.TBLCEZALAR.Sum(x => x.PARA);
            var deger4 = dbModel.TBLKITAP.Where(x => x.DURUM == false).Count();
            var deger5 = dbModel.TBLKATEGORI.Count();
            var deger6 =  dbModel.enAktifUye().FirstOrDefault();
            var deger7 = dbModel.enOkunanKitap().FirstOrDefault();
            var deger8 = dbModel.enFazlaKitapYazar().FirstOrDefault();
            var deger9 = dbModel.enCokKitapYayinevi().FirstOrDefault();
            var deger10 = dbModel.enBasariliPer().FirstOrDefault();
            var deger11 = dbModel.TBLILETISIM.Count();
            var deger12 = dbModel.TBLHAREKET.Where(x => x.ALISTARIH == DateTime.Today).Select(y => y.KITAP).Count();


            ViewBag.toplamKitap = deger1;
            ViewBag.toplamUye = deger2;
            ViewBag.toplamPara = deger3;
            ViewBag.toplamEmanet = deger4;
            ViewBag.toplamKategori = deger5;
            ViewBag.enAktifUye = deger6;
            ViewBag.enOkunanKitap = deger7;
            ViewBag.enFazlaYazar = deger8;
            ViewBag.enfazlaYayinevi = deger9;
            ViewBag.enBasariliPersonel = deger10;
            ViewBag.toplamMesaj = deger11;
            ViewBag.BugunEmanet = deger12;




            return View();
        }
    }
}