using System;
using System.Collections.Generic;
using System.Linq;
using WeekendProject.DAL.Model;

namespace WeekendProject.DAL.Interface
{
    public interface IBoekenkast
    {
        void Add(string auteur, string titel);
        void VerwijderUitBoekenkast(Boek boek);
        bool HeeftBoek(Boek boek);
        int AantalBoeken();
        void Clear();
        void VulBoekenKast();
        List<Boek> GetBoekenInBoekenKast();
        Boek GetById(int boekId);
        void WijzigBoek(string auteur, string titel, int boekId);
        void EditInbezit(Boek boek, int persoonId);
        void KrijgBoekTerug(Boek boek);
        bool LeenBoekUit(Boek boek, Persoon persoon);
        void VerwijderBoek(Boek mijnBoek);
        List<Boek> ZoekBoekenInBoekenkast(string zoekterm);
        IQueryable<string> Autocompletion(string test);
    }
}