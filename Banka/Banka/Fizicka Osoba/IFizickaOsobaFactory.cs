namespace Banka
{
    public interface IFizickaOsobaFactory
    {
        IFizickaOsoba KreirajFizickuOsobu(string ime, string prezime, string oib, VrstaRacuna izbor);
    }
}
