namespace WeekendProjectje.Tests
{
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


        public void KrijgBoekTerug()
        {
            InBib = true;
            InHetBezitVan = new Persoon("QFrame", "Nv");
        }
    }
}