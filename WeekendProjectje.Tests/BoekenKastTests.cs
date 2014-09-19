using WeekendProject.BLL;
using WeekendProject.BLL.Factory;
using WeekendProject.DAL;
using Xunit;

namespace WeekendProjectje.Tests
{
    
    public class BoekenkastTests
    {
        public BoekenkastContext Context { get; set; }
        public BoekenRepository BoekRepo { get; set; }
        public Boek TestBoek { get; set; }
        public PersonenRepository PersoonRepo { get; set; }
        public Persoon Lener { get; set; }
        public Persoon Lener2 { get; set; }
        public BoekViewModel BoekOperaties { get; set; }

        public BoekenkastTests()
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
        public void een_lijst_van_alle_boeken_wordt_weergegeven()
        {
            Assert.Equal(Boekenkast.AantalBoeken(),BoekRepo.GetAll().Count);
        }

        [Fact]
        public void een_boek_staat_niet_in_de_bibliotheek()
        {
            BoekOperaties.LeenBoekUit(TestBoek,Lener,BoekRepo);
            Assert.False(Boekenkast.HeeftBoek(TestBoek));
        }

        public void Dispose()
        {
            Boekenkast.Clear();
        }
    }
}
