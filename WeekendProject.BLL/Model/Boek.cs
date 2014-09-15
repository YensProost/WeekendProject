namespace WeekendProject.BLL
{
    public class Boek
    {
        public string Titel { get; set; }
        public string Auteur { get; set; }
        public Persoon InHetBezitVan { get; set; }

        public static int BoekNummer = 0;

        public Boek(string titel, string auteur)
        {
            Titel = titel;
            Auteur = auteur;
            BoekNummer += 1;
            BoekenKast.Add(this);
        }
    }
}