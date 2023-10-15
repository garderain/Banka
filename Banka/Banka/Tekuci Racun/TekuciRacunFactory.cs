namespace Banka
{
    public class TekuciRacunFactory : ITekuciRacunFactory
    {
        public ITekuciRacun KreirajNoviRacun()
        {
            string IBAN = UtilityClass.GenerirajNoviIBAN();

            TekuciRacun tekuciRacun = new(IBAN, 0.0f, 0.0f);

            return tekuciRacun;
        }

        public ITekuciRacun KreirajNoviRacun(float limitUplata, float limitIsplata)
        {
            string IBAN = UtilityClass.GenerirajNoviIBAN();
            TekuciRacun tekuciRacun = new(IBAN, 0.0f, 0.0f, limitUplata, limitIsplata);

            return tekuciRacun;
        }

        public ITekuciRacun KreirajNoviRacunBezLimita()
        {
            string IBAN = UtilityClass.GenerirajNoviIBAN();
            TekuciRacunBezLimita tekuciRacun = new(IBAN, 0.0f, 0.0f);

            return tekuciRacun;
        }

    }
}

