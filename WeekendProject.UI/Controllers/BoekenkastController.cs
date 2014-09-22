using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeekendProject.DAL;

namespace WeekendProject.UI.Controllers
{
    public class BoekenkastController : Controller
    {
        BoekenkastContext _database = new BoekenkastContext();
        

        public ActionResult Index()
        {
            var model = _database.Boeken.OrderBy(e => e.Auteur).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult VoegBoekToe(Boek mijnBoek)
        {
            var boekenRepository = new BoekenRepository(_database);
            var auteur = mijnBoek.Auteur;
            var titel = mijnBoek.Titel;
            boekenRepository.AddBoek(auteur, titel);
            var model = _database.Boeken.OrderBy(e => e.Auteur).ToList();
            return View("Index",model);
        }

        protected override void Dispose(bool disposing)
        {
            if (_database != null)
            {
                _database.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
