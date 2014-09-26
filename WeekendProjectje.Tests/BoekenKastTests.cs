using System;
using WeekendProject.DAL;
using WeekendProject.DAL.Model;
using WeekendProject.DAL.Repository;
using Xunit;

namespace WeekendProjectje.Tests
{
    
    public class BoekenkastTests : IDisposable
    {
        private readonly Boekenkast _boekenkast;
        public Boek TestBoek { get; set; }
        public PersonenRepository PersoonRepo { get; set; }
        public Persoon Lener { get; set; }
        public Persoon Lener2 { get; set; }

        public BoekenkastTests()
        {
            _boekenkast = new Boekenkast();
            PersoonRepo = new PersonenRepository(_boekenkast.Context);
            TestBoek = _boekenkast.GetById(1002);
            _boekenkast.VulBoekenKast();
            Lener = PersoonRepo.GetById(5);
            Lener2 = PersoonRepo.GetById(6);
        }

        [Fact(Skip = "Publish")]
        public void een_lijst_van_alle_boeken_wordt_weergegeven()
        {
            Assert.Equal(_boekenkast.AantalBoeken(),_boekenkast.GetBoekenInBoekenKast().Count);
        }

        [Fact(Skip = "Publish")]
        public void een_boek_staat_niet_in_de_bibliotheek()
        {
            _boekenkast.LeenBoekUit(TestBoek,Lener);
            Assert.False(_boekenkast.HeeftBoek(TestBoek));
            _boekenkast.KrijgBoekTerug(TestBoek);
            Assert.True(_boekenkast.HeeftBoek(TestBoek));
        }

        public void Dispose()
        {
            _boekenkast.Clear();
        }
    }
}
