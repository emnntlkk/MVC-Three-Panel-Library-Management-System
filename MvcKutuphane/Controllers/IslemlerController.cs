using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class IslemlerController : Controller
    {
        DBKUTUPHANEEntities dbModel = new DBKUTUPHANEEntities();

        // GET: Islemler
        public ActionResult IslemListele()
        {
            var degerler = dbModel.TBLHAREKET.Where(x => x.ISLEMDURUM == true).ToList();
            return View(degerler);
        }
    }
}