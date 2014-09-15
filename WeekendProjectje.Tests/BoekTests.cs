using NUnit.Framework;
using WeekendProject.BLL;
using WeekendProject.BLL.Factory;

namespace WeekendProjectje.Tests
{
    [TestFixture]
    public class BoekTests
    {
        public Persoon QFrame { get; set; }
        public Persoon Lener { get; set; }
        public Boek TestBoek { get; set; }
        public BoekViewModel BoekOperaties { get; set; }

        [SetUp]
        public void Setup()
        {
            BoekOperaties = Factory<BoekViewModel>.MaakAan();
            QFrame = Factory<Persoon>.MaakAan("QFrame", "Nv");
            Lener = Factory<Persoon>.MaakAan("Lener", "VanBoek");
            TestBoek = Factory<Boek>.MaakAan("Het leven van een javadev","Yens Proost");
        }

        [Test]
        public void een_boek_dat_uitgeleend_is_kan_niet_meer_worden_uitgeleend()
        {

            BoekOperaties.LeenBoekUit(TestBoek,Lener);
            var tweedeLener = new Persoon("Tweede", "Lener");
            Assert.IsFalse(BoekOperaties.LeenBoekUit(TestBoek,tweedeLener));
            Assert.AreNotEqual(tweedeLener.Naam,TestBoek.InHetBezitVan.Naam);
        }
        
        [Test]
        public void een_boek_dat_niet_uitgeleend_is_kan_worden_uitgeleend_en_is_in_het_bezit_van_de_lener()
        {
            Assert.IsTrue(BoekOperaties.LeenBoekUit(TestBoek,Lener));
            Assert.AreEqual(Lener.Naam, TestBoek.InHetBezitVan.Naam);
        }

        [Test]
        public void een_boek_dat_teruggebracht_word_staat_terug_in_de_bib_op_naam_van_qframe()
        {
            BoekOperaties.LeenBoekUit(TestBoek,Lener);
            BoekOperaties.KrijgBoekTerug(TestBoek);
            Assert.IsTrue(BoekenKast.HeeftBoek(TestBoek)); 
            Assert.AreEqual(QFrame.Naam, TestBoek.InHetBezitVan.Naam);
        }
    }
}