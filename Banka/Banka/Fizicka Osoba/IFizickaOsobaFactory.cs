namespace Banka
{
    public interface IFizickaOsobaFactory
    {
        IFizickaOsoba KreirajFizickuOsobu(string ime, string prezime, string oib, HashSet<VrstaRacuna> racuni);
    }
}
