using System.Web.Mvc;
using WeekendProject.DAL.Interface;
using WeekendProject.DAL.Model;

namespace WeekendProject.UI.Controllers
{
    public class BoekenkastController : Controller
    {
        private readonly IBoekenkast _boekenkast;

        public BoekenkastController(IBoekenkast boekenkast)
        {
            _boekenkast = boekenkast;
        }
        public ActionResult Index()
        {
            var model = _boekenkast.GetBoekenInBoekenKast();
            return View(model);
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
