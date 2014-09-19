using System.Collections.Generic;

namespace WeekendProject.DAL
{
    public static class Boekenkast 
    {
        private static readonly IList<Boek> BoekenLijst = new List<Boek>();

        public static void Add(Boek boek)
        {
            BoekenLijst.Add(boek);
        }

        public static void Remove(Boek boek)
        {
            BoekenLijst.Remove(boek);
        }

        public static bool HeeftBoek(Boek boek)
        {
            return BoekenLijst.Contains(boek);
        }

        public static int AantalBoeken()
        {
            return BoekenLijst.Count;
        }

        public static void Clear()
        {
            BoekenLijst.Clear();
        }
    }
}
