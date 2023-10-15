namespace Banka
{
    public interface ITekuciRacunFactory
    {
        ITekuciRacun KreirajNoviRacun();
        ITekuciRacun KreirajNoviRacun(float limitUplata, float limitIsplata);
        ITekuciRacun KreirajNoviRacunBezLimita();
    }
}

