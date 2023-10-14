namespace Banka
{
    public interface ITekuciRacun
    {
        string IBAN { get; }
        float StanjeRacuna { get; }
        float RaspoloziviIznos { get; }
        float RezerviraniIznos { get; }

        float LimitUplata { get; }
        float LimitIsplata { get; }

        bool UplatiNovac(float iznosZaUplatu);
        bool PodigniNovac(float iznosZaIsplatu);
    }
}

