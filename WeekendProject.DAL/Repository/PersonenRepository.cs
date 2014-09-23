using System.Collections.Generic;
using System.Linq;
using WeekendProject.DAL.Model;

namespace WeekendProject.DAL.Repository
{
    public class PersonenRepository
    {
        private BoekenkastContext _context;

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
}