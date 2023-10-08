namespace Banka
{
    public class FizickaOsobaFactory : IFizickaOsobaFactory
    {
        List<string> ListaOIBa = new();
        public FizickaOsobaFactory()
        {

        }
        public IFizickaOsoba KreirajFizickuOsobu(string ime, string prezime, string oib)
        {
            if (!ProvjeriOIB(oib))
            {
                throw new MalformedOibException("Neispravan OIB!");
            }
            if (ListaOIBa.Contains(oib))
            {
                throw new DuplicateOibException("OIB vec postoji");
            }

            FizickaOsoba fizickaOsoba = new(ime, prezime, oib, FactoryPool.DobaviInstancu().TekuciRacunFactory.KreirajNoviRacun(oib));
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
