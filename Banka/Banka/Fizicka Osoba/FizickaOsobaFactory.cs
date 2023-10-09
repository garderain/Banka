namespace Banka
{
    public class FizickaOsobaFactory : IFizickaOsobaFactory
    {
        List<string> ListaOIBa = new();
        public FizickaOsobaFactory()
        {

        }
        public IFizickaOsoba KreirajFizickuOsobu(string ime, string prezime, string oib, HashSet<VrstaRacuna> racuniZaIzradu)
        {
            if (!ProvjeriOIB(oib))
            {
                throw new MalformedOibException("Neispravan OIB!");
            }
            if (ListaOIBa.Contains(oib))
            {
                throw new DuplicateOibException("OIB vec postoji");
            }

            if (racuniZaIzradu.Count == 0) { throw new InvalidAccountOption("Korisnik mora imati barem jedan racun!"); }
            ITekuciRacun? tekuciRacun = null;
            IZiroRacun? ziroRacun = null;
            foreach (VrstaRacuna racun in racuniZaIzradu)
            {
                if (racun == VrstaRacuna.TEKUCI_RACUN) { tekuciRacun = FactoryPool.DobaviInstancu().TekuciRacunFactory.KreirajNoviRacun(oib); }
                else { ziroRacun = FactoryPool.DobaviInstancu().ZiroRacunFactory.KreirajZiroRacun(oib); }
            }
            FizickaOsoba fizickaOsoba = new(ime, prezime, oib, tekuciRacun, ziroRacun);
            return fizickaOsoba;
        }

        //Provjerava sastoji li se dobiveni string oib samo od znamenaka i je li duljina tocno 11 znakova
        private bool ProvjeriOIB(string oib)
        {
            foreach (char slovo in oib)
            {
                if (!Char.IsDigit(slovo)) { return false; }
            }
            if (oib.Length != 11) { return false; }
            return true;
        }
    }
}
