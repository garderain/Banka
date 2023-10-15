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
            FizickaOsoba fizickaOsoba = new(ime, prezime, oib, tekuciRacun, ziroRacun, new List<INenamjenskiKredit>());
            return fizickaOsoba;
        }

        public IFizickaOsoba KreirajFizickuOsobu(FizickaOsobaJson fizickaOsobaJson)
        {
            IZiroRacun? ziroRacun = null;
            if (fizickaOsobaJson.ZiroRacunIBAN != null)
            {
                ziroRacun = StoragePool.GetStoragePool().ZiroRacunStorage.GetZiroRacun(fizickaOsobaJson.ZiroRacunIBAN);
                if (ziroRacun == null)
                {
                    throw new MissingZiroRacunException("Ziro racun ne postoji!");
                }
            }
            ITekuciRacun? tekuciRacun = null;
            if (fizickaOsobaJson.TekuciRacunIBAN != null)
            {
                tekuciRacun = StoragePool.GetStoragePool().TekuciRacunStorage.GetTekuciRacun(fizickaOsobaJson.TekuciRacunIBAN);
                if (tekuciRacun == null)
                {
                    throw new NoTekuciRacunWithIBAN(fizickaOsobaJson.TekuciRacunIBAN);
                }
            }

            List<INenamjenskiKredit> listaNenamjenskihKredita = new();
            foreach (string idKredita in fizickaOsobaJson.ListaNenamjenskihKreditaIds)
            {
                INenamjenskiKredit? nenamjenskiKredit = StoragePool.GetStoragePool().NenamjenskiKreditStorage.GetNenamjenskiKredit(new Guid(idKredita));
                if (nenamjenskiKredit == null)
                {
                    throw new MissingNenamjenskiKreditException("Kredit ne postoji u bazi!");
                }
                listaNenamjenskihKredita.Add(nenamjenskiKredit);
            }

            FizickaOsoba fizickaOsoba = new FizickaOsoba(fizickaOsobaJson.Ime, fizickaOsobaJson.Prezime, fizickaOsobaJson.OIB, tekuciRacun, null, listaNenamjenskihKredita);
            return fizickaOsoba;
        }

        public List<IFizickaOsoba> KreirajFizickeOsobe(List<FizickaOsobaJson> fizickaOsobaJsonList)
        {
            List<IFizickaOsoba> fizickeOsobe = new();
            foreach (FizickaOsobaJson fizickaOsobaJson in fizickaOsobaJsonList)
            {
                IZiroRacun? ziroRacun = null;
                if (fizickaOsobaJson.ZiroRacunIBAN != null)
                {
                    ziroRacun = StoragePool.GetStoragePool().ZiroRacunStorage.GetZiroRacun(fizickaOsobaJson.ZiroRacunIBAN);
                    if (ziroRacun == null)
                    {
                        throw new MissingZiroRacunException("Ziro racun ne postoji!");
                    }
                }
                ITekuciRacun? tekuciRacun = null;
                if (fizickaOsobaJson.TekuciRacunIBAN != null)
                {
                    tekuciRacun = StoragePool.GetStoragePool().TekuciRacunStorage.GetTekuciRacun(fizickaOsobaJson.TekuciRacunIBAN);
                    if (tekuciRacun == null)
                    {
                        throw new NoTekuciRacunWithIBAN(fizickaOsobaJson.TekuciRacunIBAN);
                    }
                }

                List<INenamjenskiKredit> listaNenamjenskihKredita = new();
                foreach (string idKredita in fizickaOsobaJson.ListaNenamjenskihKreditaIds)
                {
                    INenamjenskiKredit? nenamjenskiKredit = StoragePool.GetStoragePool().NenamjenskiKreditStorage.GetNenamjenskiKredit(new Guid(idKredita));
                    if (nenamjenskiKredit == null)
                    {
                        throw new MissingNenamjenskiKreditException("Kredit ne postoji u bazi!");
                    }
                    listaNenamjenskihKredita.Add(nenamjenskiKredit);
                }
                FizickaOsoba fizickaOsoba = new FizickaOsoba(fizickaOsobaJson.Ime, fizickaOsobaJson.Prezime, fizickaOsobaJson.OIB, tekuciRacun, null, listaNenamjenskihKredita);
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
            foreach (INenamjenskiKredit nenamjenskiKredit in fizickaOsoba.ListaNenamjenskihKredita)
            {
                fizickaOsobaJSon.ListaNenamjenskihKreditaIds.Add(nenamjenskiKredit.IdKredit.ToString());
            }

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
                foreach (INenamjenskiKredit nenamjenskiKredit in fizickaOsoba.ListaNenamjenskihKredita)
                {
                    fizickaOsobaJSon.ListaNenamjenskihKreditaIds.Add(nenamjenskiKredit.IdKredit.ToString());
                }
                fizickaOsobaJsonList.Add(fizickaOsobaJSon);
            }

            return fizickaOsobaJsonList;
        }
    }
}
