using MarketMatikDAL.Repo;
using MarketMatikDAL.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketMatikWEB.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(VMKullanicilar data)
        {
            var kullanici = KullanicilarRepo.OturumAcHizli(data);
            if (kullanici.Yetki == "Admin")
            {
                Session["Login"] = kullanici.Benzersiz;
                return RedirectToAction("Anasayfa");
            }
            else
            {
                TempData["UyariTipi"] = "text-danger";
                TempData["Sonuc"] = "Kullanıcı Adı Yada Parolası Hatalı!";
                return View();
            }
        }
        public ActionResult Anasayfa()
        {
            if (Session["Login"] != null)
            {
                return View();
            }
            else
            {
                TempData["UyariTipi"] = "text-danger";
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Index");
            }
        }
        public ActionResult Logoff()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}