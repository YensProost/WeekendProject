using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq;
using Xunit;

namespace WeekendProject.DAL
{
    public class PersonenRepository
    {
        private readonly BoekenkastContext _context;

        public PersonenRepository(BoekenkastContext context)
        {
            _context = context;
        }

        public Persoon AddPersoon(string voornaam, string achternaam)
        {
            var toegevoegdePersoon = _context.Personen.Add(new Persoon() {Voornaam = voornaam, Achternaam = achternaam});
            _context.SaveChanges();
            return toegevoegdePersoon;
        }

        public IList<Persoon> GetAll()
        {
            return _context.Personen.ToList();
        }

        public Persoon GetById(int id)
        {
            return _context.Personen.FirstOrDefault(e => e.PersoonId == id);
        }
    }
    
    public class BoekenRepository 
    {
        private readonly BoekenkastContext _context;

        public BoekenRepository(BoekenkastContext context)
        {
            _context = context;
        }

        public Boek AddBoek(string auteur, string titel)
        {
            var toeTeVoegenBoek = new Boek() {Auteur = auteur, Titel = titel, PersoonId = 4};
            Boekenkast.Add(toeTeVoegenBoek);
            var toegevoegdBoek = _context.Boeken.Add(toeTeVoegenBoek);
            _context.SaveChanges();
            return toegevoegdBoek;
        }

        public virtual IList<Boek> GetAll()
        {
            return _context.Boeken.ToList();
        }

        public void EditInbezit(Boek boek, int persoonId = 4)
        {
            var boekUitDb = _context.Boeken.Single(e => e.BoekId == boek.BoekId);
            boekUitDb.PersoonId = persoonId;
            _context.SaveChanges();
        }

        public Boek GetById(int id)
        {
            return _context.Boeken.FirstOrDefault(e => e.BoekId == id);
        }
    }
}