using WeekendProject.DAL;

namespace WeekendProject.BLL
{
    public class BoekViewModel
    {
        public bool LeenBoekUit(Boek boek ,Persoon persoon, BoekenRepository boekRepository)
        {
            if (!Boekenkast.HeeftBoek(boek)) return false;
            boekRepository.EditInbezit(boek,persoon.PersoonId);
            Boekenkast.Remove(boek);
            return true;
        }


        public void KrijgBoekTerug(Boek boek,BoekenRepository boekenRepository)
        {
            boekenRepository.EditInbezit(boek);
            Boekenkast.Add(boek);
        }
    }
}
