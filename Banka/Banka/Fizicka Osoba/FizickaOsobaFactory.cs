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
                if (racun == VrstaRacuna.TEKUCI_RACUN) { tekuciRacun = FactoryPool.DobaviInstancu().TekuciRacunFactory.KreirajNoviRacun(); }
                else { ziroRacun = FactoryPool.DobaviInstancu().ZiroRacunFactory.KreirajZiroRacun(); }
            }
            FizickaOsoba fizickaOsoba = new(ime, prezime, oib, tekuciRacun, ziroRacun);
            return fizickaOsoba;
        }

        public IFizickaOsoba KreirajFizickuOsobu(FizickaOsobaJson fizickaOsobaJson)
        {
            ITekuciRacun? tekuciRacun = null;
            if (fizickaOsobaJson.TekuciRacunIBAN != null)
            {
                tekuciRacun = StoragePool.GetStoragePool().TekuciRacunStorage.GetTekuciRacun(fizickaOsobaJson.TekuciRacunIBAN);
                if (tekuciRacun == null)
                {
                    throw new NoTekuciRacunWithIBAN(fizickaOsobaJson.TekuciRacunIBAN);
                }
            }
            FizickaOsoba fizickaOsoba = new FizickaOsoba(fizickaOsobaJson.Ime, fizickaOsobaJson.Prezime, fizickaOsobaJson.OIB, tekuciRacun, null);
            return fizickaOsoba;
        }

        public List<IFizickaOsoba> KreirajFizickeOsobe(List<FizickaOsobaJson> fizickaOsobaJsonList)
        {
            List<IFizickaOsoba> fizickeOsobe = new();
            foreach (FizickaOsobaJson fizickaOsobaJson in fizickaOsobaJsonList)
            {
                ITekuciRacun? tekuciRacun = null;
                if (fizickaOsobaJson.TekuciRacunIBAN != null)
                {
                    tekuciRacun = StoragePool.GetStoragePool().TekuciRacunStorage.GetTekuciRacun(fizickaOsobaJson.TekuciRacunIBAN);
                    if (tekuciRacun == null)
                    {
                        throw new NoTekuciRacunWithIBAN(fizickaOsobaJson.TekuciRacunIBAN);
                    }
                }
                FizickaOsoba fizickaOsoba = new FizickaOsoba(fizickaOsobaJson.Ime, fizickaOsobaJson.Prezime, fizickaOsobaJson.OIB, tekuciRacun, null);
                fizickeOsobe.Add(fizickaOsoba);
            }
            return fizickeOsobe;
        }

        public FizickaOsobaJson KreirajZapisFizickeOsobe(IFizickaOsoba iFizickaOsoba)
        {
            FizickaOsoba fizickaOsoba = (FizickaOsoba)iFizickaOsoba;
            FizickaOsobaJson fizickaOsobaJSon = new();
            fizickaOsobaJSon.Ime = fizickaOsoba.Ime;
            fizickaOsobaJSon.Prezime = fizickaOsoba.Prezime;
            fizickaOsobaJSon.OIB = fizickaOsoba.OIB;
            fizickaOsobaJSon.TekuciRacunIBAN = fizickaOsoba.TekuciRacun == null ? null : fizickaOsoba.TekuciRacun.IBAN;
            fizickaOsobaJSon.ZiroRacunIBAN = fizickaOsoba.ZiroRacun == null ? null : fizickaOsoba.ZiroRacun.IBAN;
            return fizickaOsobaJSon;
        }

        public List<FizickaOsobaJson> KreirajZapisFizickihOsoba(List<IFizickaOsoba> iFizickaOsobaList)
        {
            List<FizickaOsobaJson> fizickaOsobaJsonList = new();
            foreach (IFizickaOsoba iFizickaOsoba in iFizickaOsobaList)
            {
                FizickaOsoba fizickaOsoba = (FizickaOsoba)iFizickaOsoba;
                FizickaOsobaJson fizickaOsobaJSon = new();
                fizickaOsobaJSon.Ime = fizickaOsoba.Ime;
                fizickaOsobaJSon.Prezime = fizickaOsoba.Prezime;
                fizickaOsobaJSon.OIB = fizickaOsoba.OIB;
                fizickaOsobaJSon.TekuciRacunIBAN = fizickaOsoba.TekuciRacun == null ? null : fizickaOsoba.TekuciRacun.IBAN;
                fizickaOsobaJSon.ZiroRacunIBAN = fizickaOsoba.ZiroRacun == null ? null : fizickaOsoba.ZiroRacun.IBAN;
                fizickaOsobaJsonList.Add(fizickaOsobaJSon);
            }

            return fizickaOsobaJsonList;
        }

        public void DodajKreditUListu(List<INenamjenskiKredit> listaKredita, INenamjenskiKredit nenamjenskiKredit)
        { if (!listaKredita.Contains(nenamjenskiKredit)) { listaKredita.Add(nenamjenskiKredit); } }
    }
}
