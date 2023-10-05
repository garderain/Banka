using System;
namespace Banka
{
	public interface ITekuciRacun
	{
        string IBAN { get; }
        float StanjeRacuna { get; }
        float RaspoloziviIznos { get; }
        float RezerviraniIznos { get; }

        bool UplatiNovac(float iznosZaUplatu);
        bool PodigniNovac(float iznosZaIsplatu);
    }
}

