using WeekendProject.BLL;
using WeekendProject.BLL.Factory;
using WeekendProject.DAL;
using Xunit;

namespace WeekendProjectje.Tests
{
    public class BoekTests
    {
        public BoekenkastContext Context { get; set; }
        public BoekenRepository BoekRepo { get; set; }
        public Boek TestBoek { get; set; }
        public PersonenRepository PersoonRepo { get; set; }
        public Persoon Lener { get; set; }
        public Persoon Lener2 { get; set; }
        public BoekViewModel BoekOperaties { get; set; }

        public BoekTests()
        {
            BoekOperaties = Factory<BoekViewModel>.MaakAan();
            Context = new BoekenkastContext();
            PersoonRepo = new PersonenRepository(Context);
            BoekRepo = new BoekenRepository(Context);
            TestBoek = BoekRepo.GetById(2);
            Boekenkast.Add(TestBoek);
            Lener = PersoonRepo.GetById(5);
            Lener2 = PersoonRepo.GetById(6);
        }
        
        [Fact]
        public void een_boek_dat_uitgeleend_is_kan_niet_meer_worden_uitgeleend()
        {
            BoekOperaties.LeenBoekUit(TestBoek,Lener,BoekRepo);

            Assert.False(BoekOperaties.LeenBoekUit(TestBoek,Lener2,BoekRepo));
            Assert.NotEqual(Lener2.PersoonId,TestBoek.PersoonId);
        }

        
        [Fact]
        public void een_boek_dat_niet_uitgeleend_is_kan_worden_uitgeleend_en_is_in_het_bezit_van_de_lener()
        {
            Assert.True(BoekOperaties.LeenBoekUit(TestBoek,Lener,BoekRepo));
            Assert.Equal(Lener.PersoonId, TestBoek.PersoonId);
        }

        [Fact]
        public void een_boek_dat_teruggebracht_word_staat_terug_in_de_bib_op_naam_van_qframe()
        {
            BoekOperaties.LeenBoekUit(TestBoek,Lener,BoekRepo);
            BoekOperaties.KrijgBoekTerug(TestBoek,BoekRepo);

            Assert.True(Boekenkast.HeeftBoek(TestBoek)); 
            Assert.Equal(PersoonRepo.GetById(4).PersoonId, TestBoek.PersoonId);
        }

        public void Dispose()
        {
            Boekenkast.Clear();
        }
    }
}