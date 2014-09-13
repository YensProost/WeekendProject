using System.Collections.Generic;

namespace WeekendProjectje.Tests
{
    public class Persoon
    {
        public string Naam { get; set; }

        public Persoon(string voornaam,string achternaam)
        {
            Naam = string.Format("{0} {1}", voornaam, achternaam);
        }
    }
}