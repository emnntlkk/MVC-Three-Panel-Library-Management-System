using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        DBKUTUPHANEEntities dbModel = new DBKUTUPHANEEntities();

        
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(TBLUYELER prmt)
        {
            var bilgiler = dbModel.TBLUYELER.FirstOrDefault(x => x.MAIL == prmt.MAIL && x.SIFRE == prmt.SIFRE);
            if(bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["Mail"] = bilgiler.MAIL.ToString();
               
                Session["Ad"] = bilgiler.AD.ToString();
                Session["Soyad"] = bilgiler.SOYAD.ToString();
             
                Session["Okul"] = bilgiler.OKUL.ToString();
                
                return RedirectToAction("Panel","Panelim");
            }
            else
            {
                return View();
            }
        }
    }
}