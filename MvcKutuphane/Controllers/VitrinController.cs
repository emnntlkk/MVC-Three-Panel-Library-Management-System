using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.Siniflarim;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class VitrinController : Controller
    {
        // GET: Vitrin

        DBKUTUPHANEEntities dbModel = new DBKUTUPHANEEntities();

        [HttpGet]
        public ActionResult vitrin()

        {
            TabloListele tablo = new TabloListele();
            tablo.tablo1 = dbModel.TBLKITAP.Take(9).ToList();
            tablo.tablo2 = dbModel.TBLHAKKIMIZDA.ToList();
            return View(tablo);
        }

        [HttpPost]
        public ActionResult vitrin(TBLILETISIM t)
        {
            dbModel.TBLILETISIM.Add(t);
            dbModel.SaveChanges();
            return RedirectToAction("vitrin");

        }
    }
}