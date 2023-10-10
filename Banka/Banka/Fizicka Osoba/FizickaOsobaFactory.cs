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



    }
}
