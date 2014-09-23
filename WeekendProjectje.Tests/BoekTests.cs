using System;
using WeekendProject.DAL;
using WeekendProject.DAL.Model;
using WeekendProject.DAL.Repository;
using Xunit;

namespace WeekendProjectje.Tests
{
    public class BoekTests : IDisposable
    {
        private readonly Boekenkast _boekenkast;
        public Boek TestBoek { get; set; }
        public PersonenRepository PersoonRepo { get; set; }
        public Persoon Lener { get; set; }
        public Persoon Lener2 { get; set; }

        public BoekTests()
        {
            _boekenkast = new Boekenkast();
            PersoonRepo = new PersonenRepository(_boekenkast.Context);
            TestBoek = _boekenkast.GetById(1002);
            _boekenkast.VulBoekenKast();
            Lener = PersoonRepo.GetById(5);
            Lener2 = PersoonRepo.GetById(6);
        }
        
        [Fact]
        public void een_boek_dat_uitgeleend_is_kan_niet_meer_worden_uitgeleend()
        {
            _boekenkast.LeenBoekUit(TestBoek,Lener);

            Assert.False(_boekenkast.LeenBoekUit(TestBoek,Lener2));
            Assert.NotEqual(Lener2.PersoonId,TestBoek.PersoonId);
            ZetBoekTerug();
        }


        [Fact]
        public void een_boek_dat_niet_uitgeleend_is_kan_worden_uitgeleend_en_is_in_het_bezit_van_de_lener()
        {
            Assert.True(_boekenkast.LeenBoekUit(TestBoek,Lener));
            Assert.Equal(Lener.PersoonId, TestBoek.PersoonId);
            ZetBoekTerug();
            Assert.True(_boekenkast.HeeftBoek(TestBoek));
        }

        [Fact]
        public void een_boek_dat_teruggebracht_word_staat_terug_in_de_bib_op_naam_van_qframe()
        {
            _boekenkast.LeenBoekUit(TestBoek,Lener);
            ZetBoekTerug();

            Assert.True(_boekenkast.HeeftBoek(TestBoek)); 
            Assert.Equal(PersoonRepo.GetById(4).PersoonId, TestBoek.PersoonId);
        }

        private void ZetBoekTerug()
        {
            _boekenkast.KrijgBoekTerug(TestBoek);
        }

        public void Dispose()
        {
            _boekenkast.Clear();
        }
    }
}