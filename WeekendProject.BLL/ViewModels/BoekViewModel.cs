namespace WeekendProject.BLL
{
    public class BoekViewModel
    {
        public bool LeenBoekUit(Boek boek ,Persoon persoon)
        {
            if (!BoekenKast.HeeftBoek(boek)) return false;
            BoekenKast.Remove(boek);
            boek.InHetBezitVan = persoon;
            return true;
        }


        public void KrijgBoekTerug(Boek boek)
        {
            BoekenKast.Add(boek);
            boek.InHetBezitVan = new Persoon("QFrame", "Nv");
        }
    }
}
