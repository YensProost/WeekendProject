using NUnit.Framework;
using WeekendProjectje.Tests;

namespace WeekendProjectje.Tests
{
    [TestFixture]
    public class BoekTests
    {
        public Persoon QFrame { get; set; }
        public Persoon Ken { get; set; }
        public Boek TestBoek { get; set; }

        [SetUp]
        public void Setup()
        {
            QFrame = Factory<Persoon>.MaakAan("QFrame", "Nv");
            Ken = Factory<Persoon>.MaakAan("Ken", "de Meyer");
            TestBoek = Factory<Boek>.MaakAan("Het leven van een javadev","Yens Proost");
        }

        [Test]
        public void een_boek_staat_in_de_bibliotheek()
        {
            Assert.IsTrue(TestBoek.InBib);
        }

        [Test]
        public void een_boek_staat_niet_in_de_bibliotheek()
        {
            TestBoek.LeenBoekUit(Ken);
            Assert.IsFalse(TestBoek.InBib);
        }

        [Test]
        public void een_boek_dat_uitgeleend_is_kan_niet_meer_worden_uitgeleend()
        {

            TestBoek.LeenBoekUit(Ken);
            var tweedeLener = new Persoon("Petra", "Liesmons");
            Assert.IsFalse(TestBoek.LeenBoekUit(tweedeLener));
            Assert.AreNotEqual(tweedeLener.Naam,TestBoek.InHetBezitVan.Naam);
        }
        
        [Test]
        public void een_boek_dat_niet_uitgeleend_is_kan_worden_uitgeleend_en_is_in_het_bezit_van_de_lener()
        {
            Assert.IsTrue(TestBoek.LeenBoekUit(Ken));
            Assert.AreEqual(Ken.Naam, TestBoek.InHetBezitVan.Naam);
        }

        [Test]
        public void een_boek_dat_teruggebracht_word_staat_terug_in_de_bib()
        {

            TestBoek.LeenBoekUit(Ken);
            TestBoek.KrijgBoekTerug();
            Assert.IsTrue(TestBoek.InBib);
        }
        
        [Test]
        public void een_boek_dat_teruggebracht_word_staat_op_naam_van_qframe()
        {
            TestBoek.LeenBoekUit(Ken);
            TestBoek.KrijgBoekTerug();
            Assert.AreEqual(QFrame.Naam, TestBoek.InHetBezitVan.Naam);
        }
    }
}