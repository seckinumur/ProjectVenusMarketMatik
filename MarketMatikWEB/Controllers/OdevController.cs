using MarketMatikDAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketMatikWEB.Controllers
{
    public class OdevController : Controller
    {
        // GET: Odev
        public ActionResult Kategori()
        {
            if (Session["Login"] != null)
            {
                ViewBag.KEY = Session["Login"].ToString();
                return View();
            }
            else
            {
                TempData["UyariTipi"] = "text-danger";
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Marka()
        {
            if (Session["Login"] != null)
            {
                ViewBag.KEY = Session["Login"].ToString();
                return View();
            }
            else
            {
                TempData["UyariTipi"] = "text-danger";
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Kampanya()
        {
            if (Session["Login"] != null)
            {
                ViewBag.KEY = Session["Login"].ToString();
                return View();
            }
            else
            {
                TempData["UyariTipi"] = "text-danger";
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Urun()
        {
            if (Session["Login"] != null)
            {
                return View();
            }
            else
            {
                TempData["UyariTipi"] = "text-danger";
                TempData["Sonuc"] = "Tarayıcıda Oturum Süreniz Dolmuş! Lütfen Tekrar Oturum Açın!";
                return RedirectToAction("Index", "Login");
            }
        }
    }
}