namespace Banka.Ziro_Racun
{
    public interface IZiroRacunFactory
    {
        IZiroRacun KreirajZiroRacun(string ime, string prezime, string OIB);
    }
}
