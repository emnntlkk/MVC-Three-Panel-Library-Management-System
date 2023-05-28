using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin

        DBKUTUPHANEEntities DbModel = new DBKUTUPHANEEntities();
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(TBLADMIN admin)
        {
            var bilgiler = DbModel.TBLADMIN.FirstOrDefault(x => x.KULLANICI == admin.KULLANICI && x.SIFRE == admin.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KULLANICI, false);
                Session["Kullanici"] = bilgiler.KULLANICI.ToString();
                return RedirectToAction("Index","Kategori");
            }
            return View();
        }
    }
}