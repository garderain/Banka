namespace Banka
{
    public interface ITekuciRacunFactory
    {
        ITekuciRacun KreirajNoviRacun();
        ITekuciRacun KreirajNoviRacun(float limitUplata, float limitIsplata);
        ITekuciRacun KreirajNoviRacunBezLimita();
        ITekuciRacun KreirajPostojeciRacun(string IBAN, float stanjeRacuna, float rezerviraniIznos, float limitUplata, float limitIsplata);
        List<ITekuciRacun> KreirajTekuceRacune(List<TekuciRacunJson> tekuciRacuniJson);
        ITekuciRacun KreirajTekuciracunIzBaze(TekuciRacunJson tekuciRacunJson);
        public List<TekuciRacunJson> KreirajZapisTekucihRacuna(List<ITekuciRacun> listaTekucihRacuna);
    }
}

