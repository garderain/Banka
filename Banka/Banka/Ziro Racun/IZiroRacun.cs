namespace Banka
{
    public interface IZiroRacun
    {

        float StanjeRacuna { get; }
        string? IBAN { get; }
        float RaspoloziviIznos { get; }
        float RezerviraniDio { get; }
        float LimitUplate { get; }
        float LimitIsplate { get; }

        bool UplatiNovac(float IznosZaUplatu);
        bool IsplatiNovac(float IznosZaIsplatu);



    }
}
