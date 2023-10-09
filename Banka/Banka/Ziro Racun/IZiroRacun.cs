namespace Banka
{
    public interface IZiroRacun
    {

        float StanjeRacuna { get; }
        string? IBAN { get; }
        float RaspoloziviIznos { get; }

        bool UplatiNovac(float IznosZaUplatu);
        bool IsplatiNovac(float IznosZaIsplatu);



    }
}
