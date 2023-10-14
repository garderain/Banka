namespace Banka
{
    public interface IFizickaOsobaFactory
    {
        IFizickaOsoba KreirajFizickuOsobu(string ime, string prezime, string oib, HashSet<VrstaRacuna> racuni);
        IFizickaOsoba KreirajFizickuOsobu(FizickaOsobaJson fizickaOsobaJson);
        List<IFizickaOsoba> KreirajFizickeOsobe(List<FizickaOsobaJson> fizickaOsobaJsonList);
        FizickaOsobaJson KreirajZapisFizickeOsobe(IFizickaOsoba iFizickaOsoba);
        List<FizickaOsobaJson> KreirajZapisFizickihOsoba(List<IFizickaOsoba> iFizickaOsobaList);
        void DodajKreditUListu(List<INenamjenskiKredit> listaKredita, INenamjenskiKredit nenamjenskiKredit);
    }
}
