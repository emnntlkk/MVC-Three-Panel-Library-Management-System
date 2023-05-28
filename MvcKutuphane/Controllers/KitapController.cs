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
    public class KitapController : Controller
    {
        // GET: Kitap

        DBKUTUPHANEEntities DbModel = new DBKUTUPHANEEntities();
        public ActionResult kitapListele(string search, int ? page)
        {
            return View(DbModel.TBLKITAP.Where(x => x.KITAPAD.Contains(search) || search == null).ToList().ToPagedList(page ?? 1, 5));

           
           
        }

        [HttpGet]
        public ActionResult kitapEkle()
        {
            List<SelectListItem> kitapDeger = (from i in DbModel.TBLKATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.KATEGORIID.ToString()
                                           }).ToList();
            ViewBag.ktpDgr = kitapDeger;

            List<SelectListItem> yazarDeger = (from i in DbModel.TBLYAZAR.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.AD +' '+i.SOYAD,
                                                    Value = i.YAZARID.ToString()
                                                }).ToList();
            ViewBag.yzrDgr = yazarDeger;
            return View();

        }

        [HttpPost]
        public ActionResult kitapEkle(TBLKITAP kitap)
        {
            var ktg = DbModel.TBLKATEGORI.Where(k => k.KATEGORIID ==kitap.TBLKATEGORI.KATEGORIID).FirstOrDefault();
            var yzr = DbModel.TBLYAZAR.Where(y => y.YAZARID == kitap.TBLYAZAR.YAZARID).FirstOrDefault();
            kitap.TBLKATEGORI = ktg;
            kitap.TBLYAZAR = yzr;
            DbModel.TBLKITAP.Add(kitap);
            DbModel.SaveChanges();
            return RedirectToAction("kitapListele");
        }

        public ActionResult kitapSil(int id)
        {
            var kitap = DbModel.TBLKITAP.Find(id);
            DbModel.TBLKITAP.Remove(kitap);
            DbModel.SaveChanges();
            return RedirectToAction("kitaplistele");
        }

        public ActionResult kitapGetir(int id)
        {
            var kitap = DbModel.TBLKITAP.Find(id);

            List<SelectListItem> kitapDeger = (from i in DbModel.TBLKATEGORI.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.AD,
                                                   Value = i.KATEGORIID.ToString()
                                               }).ToList();
            ViewBag.ktpDgr = kitapDeger;

            List<SelectListItem> yazarDeger = (from i in DbModel.TBLYAZAR.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.AD + ' ' + i.SOYAD,
                                                   Value = i.YAZARID.ToString()
                                               }).ToList();
            ViewBag.yzrDgr = yazarDeger;

            return View(kitap);

        }


        public ActionResult kitapGuncelle(TBLKITAP prmt) 
        {
            var kitap = DbModel.TBLKITAP.Find(prmt.KITAPID);
            kitap.KITAPAD = prmt.KITAPAD;
            kitap.BASIMYIL = prmt.BASIMYIL;
            kitap.SAYFA = prmt.SAYFA;
            kitap.YAYINEVİ = prmt.YAYINEVİ;
            kitap.DURUM = true;
            var ktg = DbModel.TBLKATEGORI.Where(k => k.KATEGORIID == prmt.TBLKATEGORI.KATEGORIID).FirstOrDefault();

            var yzr = DbModel.TBLYAZAR.Where(y=> y.YAZARID== prmt.TBLYAZAR.YAZARID).FirstOrDefault();

            kitap.KATEGORI = ktg.KATEGORIID;
            kitap.YAZAR = yzr.YAZARID;
            DbModel.SaveChanges();

            return RedirectToAction("kitapListele");
        }

    }
}