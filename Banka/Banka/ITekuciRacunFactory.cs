using System;
namespace Banka
{
	public interface ITekuciRacunFactory
	{
        ITekuciRacun KreirajNoviRacun(string vlasnikOIB);
        ITekuciRacun KreirajNoviRacun(string vlasnikOIB, float limitUplata, float limitIsplata);
        ITekuciRacun KreirajNoviRacunBezLimita(string vlasnikOIB);
    }
}

