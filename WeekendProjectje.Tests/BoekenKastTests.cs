using NUnit.Framework;
using WeekendProject.BLL;
using WeekendProject.BLL.Factory;

namespace WeekendProjectje.Tests
{
    [TestFixture]
    public class BoekenKastTests
    {
        [Test]
        public void een_boek_staat_in_de_bibliotheek_als_het_aangekocht_word()
        {
            var boek = Factory<Boek>.MaakAan("Het leven van een javadev","Yens Proost");
            Assert.IsTrue(BoekenKast.HeeftBoek(boek));
        }

        [Test]
        public void een_boek_staat_niet_in_de_bibliotheek()
        {
            var boek = Factory<Boek>.MaakAan("Het leven van een javadev", "Yens Proost");
            var lener = Factory<Persoon>.MaakAan("John", "Doe");
            var boekOperaties = Factory<BoekViewModel>.MaakAan();
            boekOperaties.LeenBoekUit(boek,lener);
            Assert.IsFalse(BoekenKast.HeeftBoek(boek));
        }

    }
}
