namespace Banka
{
    public interface ITekuciRacunFactory
    {
        ITekuciRacun KreirajNoviRacun();
        ITekuciRacun KreirajNoviRacun(float limitUplata, float limitIsplata);
        ITekuciRacun KreirajNoviRacunBezLimita();
        List<ITekuciRacun> KreirajTekuceRacune(List<TekuciRacunJson> tekuciRacuniJson);
        ITekuciRacun KreirajTekuciracunIzBaze(TekuciRacunJson tekuciRacunJson);
        List<TekuciRacunJson> KreirajZapisTekucihRacuna(List<ITekuciRacun> listaTekucihRacuna);
    }
}

