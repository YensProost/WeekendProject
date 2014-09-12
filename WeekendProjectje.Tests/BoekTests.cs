using NUnit.Framework;

namespace WeekendProjectje.Tests
{
    [TestFixture]
    public class BoekTests
    {
        private readonly Persoon _lener = new Persoon("Ken","de Meyer");

        [Test]
        public void een_boek_staat_in_de_bibliotheek()
        {
            var sut = new Boek("Het leven van een javadev","Yens Proost");
            Assert.IsTrue(sut.InBib);
        }

        [Test]
        public void een_boek_staat_niet_in_de_bibliotheek()
        {
            var sut = new Boek("Het leven van een javadev", "Yens Proost");
            sut.LeenBoekUit(_lener);
            Assert.IsFalse(sut.InBib);
        }

        [Test]
        public void een_boek_dat_uitgeleend_is_kan_niet_meer_worden_uitgeleend()
        {
            var sut = new Boek("Het leven van een javadev", "Yens Proost");
            sut.LeenBoekUit(_lener);
            var tweedeLener = new Persoon("Petra", "Liesmons");
            Assert.IsFalse(sut.LeenBoekUit(tweedeLener));
            Assert.AreNotEqual(tweedeLener.Naam,sut.InHetBezitVan.Naam);
        }
        
        [Test]
        public void een_boek_dat_niet_uitgeleend_is_kan_worden_uitgeleend()
        {
            var sut = new Boek("Het leven van een javadev", "Yens Proost");
            
            Assert.IsTrue(sut.LeenBoekUit(new Persoon("Petra","Liesmons")));
        }

        [Test]
        public void een_boek_is_in_het_bezit_van_de_persoon_aan_wie_het_uitgeleend_wordt()
        {
            var sut = new Boek("Dit is mijn boek", "Yens Proost");
            sut.LeenBoekUit(_lener);

            Assert.AreEqual(_lener.Naam,sut.InHetBezitVan.Naam);
        }
    }

    public class Boek
    {
        public bool InBib { get; set; }
        public string Titel { get; set; }
        public string Auteur { get; set; }
        public Persoon InHetBezitVan { get; set; }

        public static int BoekNummer = 0;

        public Boek(string titel, string auteur)
        {
            Titel = titel;
            Auteur = auteur;
            BoekNummer += 1;
            InBib = true;
        }

        public bool LeenBoekUit(Persoon persoon)
        {
            
            if (InBib)
            {
                InBib = false;
                InHetBezitVan = persoon;
                return true;
            }
            InBib = true;
            return false;
        }

        
    }

    public class Persoon
    {
        public string Naam { get; set; }

        public Persoon(string voornaam,string achternaam)
        {
            Naam = string.Format("{0} {1}", voornaam, achternaam);
        }
    }
}