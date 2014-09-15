using System.Collections.Generic;

namespace WeekendProject.BLL
{
    public class Persoon
    {
        public static IList<Persoon> Personenlijst = new List<Persoon>(); 
        public string Naam { get; set; }

        public Persoon(string voornaam,string achternaam)
        {
            Naam = string.Format("{0} {1}", voornaam, achternaam);
            Personenlijst.Add(this);
        }
    }
}