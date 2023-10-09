namespace Banka.Ziro_Racun
{
    public interface IZiroRacun
    {

        float StanjeRacuna { get; }
        string IBAN { get; }
        string Ime { get; }
        string Prezime { get; }
        float RaspoloziviIznos { get; }

        bool UplatiNovac(float IznosZaUplatu);
        bool IsplatiNovac(float IznosZaIsplatu);



    }
}
