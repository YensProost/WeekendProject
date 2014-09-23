using System.Collections.Generic;
using System.Linq;
using WeekendProject.DAL.Model;

namespace WeekendProject.DAL.Repository
{
    public class BoekenRepository 
    {
        private readonly BoekenkastContext _context;

        public BoekenRepository(BoekenkastContext context)
        {
            _context = context;
        }

        public Boek AddBoek(string auteur, string titel)
        {
            var toegevoegdBoek = _context.Boeken.Add(new Boek { Auteur = auteur, Titel = titel, PersoonId = 4 });
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

        public List<Boek> GetByPersoonId(int i)
        {
            return _context.Boeken.Where(e => e.PersoonId == 4).ToList();
        }

        public void WijzigBoek(string auteur, string titel, int boekId)
        {
            var boek = _context.Boeken.Single(e => e.BoekId == boekId);
            boek.Auteur = auteur;
            boek.Titel = titel;
            _context.SaveChanges();
        }

        public void Remove(Boek boek)
        {
            _context.Boeken.Remove(_context.Boeken.First(e => e.BoekId == boek.BoekId));
            _context.SaveChanges();
        }
    }
}