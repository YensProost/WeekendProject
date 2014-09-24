using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using Antlr.Runtime.Misc;
using WeekendProject.DAL;
using WeekendProject.DAL.Interface;
using WeekendProject.DAL.Model;

namespace WeekendProject.UI.Controllers
{
    public class BoekenkastController : Controller
    {
        BoekenkastContext _context = new BoekenkastContext();
        private readonly IBoekenkast _boekenkast;

        public BoekenkastController(IBoekenkast boekenkast)
        {
            _boekenkast = boekenkast;
        }
        public ActionResult Index(string zoekterm = null, int page = 1)
        {
            var model = zoekterm ==null ? _boekenkast.GetBoekenInBoekenKast() : _boekenkast.ZoekBoekenInBoekenkast(zoekterm);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Boeken", model);
            }
            return View(model);
        }

        public ActionResult Autocomplete(string term)
        {
            var model = _context.Boeken.Where(r => r.Titel.StartsWith(term))
                                  .Take(10)
                                  .Select(r => r.Titel);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Wijzig(int boekId)
        {
            var model = _boekenkast.GetById(boekId);
            return View(model);
        }
        
        public ActionResult Verwijder(int boekId)
        {
            var model = _boekenkast.GetById(boekId);
            return View(model);
        }

        public ActionResult VoegBoekToe(Boek mijnBoek)
        {
            _boekenkast.Add(mijnBoek.Auteur, mijnBoek.Titel);
            var model = _boekenkast.GetBoekenInBoekenKast();
            return View("Index", model);
        }

        public ActionResult WijzigBoek(Boek mijnBoek)
        {
            _boekenkast.WijzigBoek(mijnBoek.Auteur, mijnBoek.Titel,mijnBoek.BoekId);
            var model = _boekenkast.GetBoekenInBoekenKast();
            return View("Index",model);
        }

        public ActionResult VerwijderBoek(Boek mijnBoek)
        {
            _boekenkast.VerwijderBoek(mijnBoek);
            var model = _boekenkast.GetBoekenInBoekenKast();
            return View("Index", model);
        }
    }
}
