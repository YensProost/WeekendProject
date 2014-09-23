using System.Collections.Generic;
using System.Linq;
using WeekendProject.DAL.Interface;
using WeekendProject.DAL.Model;
using WeekendProject.DAL.Repository;

namespace WeekendProject.DAL
{
    public class Boekenkast : IBoekenkast
    {
        private readonly BoekenRepository _boekRepo;
        private readonly BoekenkastContext _context;

        public BoekenkastContext Context
        {
            get
            {
                return _context ?? new BoekenkastContext();
            }
        }

        public Boekenkast()
        {
            _context = Context;
            _boekRepo = new BoekenRepository(_context);
        }

        private static readonly IList<Boek> BoekenLijst = new List<Boek>();

        public void Add(string auteur, string titel)
        {
            BoekenLijst.Add(_boekRepo.AddBoek(auteur, titel));
        }

        public void VerwijderUitBoekenkast(Boek boek)
        {
            BoekenLijst.Remove(boek);
        }

        public bool HeeftBoek(Boek boek)
        {
            return BoekenLijst.Contains(boek);
        }

        public int AantalBoeken()
        {
            return BoekenLijst.Count;
        }

        public void Clear()
        {
            BoekenLijst.Clear();
        }

        public void VulBoekenKast()
        {
            foreach (var boek in _boekRepo.GetByPersoonId(4))
            {
                BoekenLijst.Add(boek);
            }
        }

        public List<Boek> GetBoekenInBoekenKast()
        {
            return _context.Boeken.Where(e => e.PersoonId == 4)
                .OrderBy(e => e.Auteur)
                .ToList();
        }

        public Boek GetById(int boekId)
        {
            return _boekRepo.GetById(boekId);
        }

        public void WijzigBoek(string auteur, string titel, int boekId)
        {
            _boekRepo.WijzigBoek(auteur,titel,boekId);
        }

        public void EditInbezit(Boek boek, int persoonId)
        {
            _boekRepo.EditInbezit(boek,persoonId);
        }

        public bool LeenBoekUit(Boek boek, Persoon persoon)
        {
            if (!HeeftBoek(boek)) return false;
            EditInbezit(boek, persoon.PersoonId);
            VerwijderUitBoekenkast(boek);
            return true;
        }

        public void VerwijderBoek(Boek mijnBoek)
        {
            _boekRepo.Remove(mijnBoek);
        }

        public void KrijgBoekTerug(Boek boek)
        {
            _boekRepo.EditInbezit(boek);
            BoekenLijst.Add(_boekRepo.GetById(boek.BoekId));
        }
    }
}
