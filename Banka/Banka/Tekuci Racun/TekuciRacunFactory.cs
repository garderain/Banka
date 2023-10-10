namespace Banka
{
    public class TekuciRacunFactory : ITekuciRacunFactory
    {
        public ITekuciRacun KreirajNoviRacun(string vlasnikOIB)
        {
            UtilityClass.ProvjeriOIB(vlasnikOIB);
            string IBAN = UtilityClass.GenerirajNoviIBAN();

            TekuciRacun tekuciRacun = new(IBAN, 0.0f, 0.0f, vlasnikOIB);

            return tekuciRacun;
        }

        public ITekuciRacun KreirajNoviRacun(string vlasnikOIB, float limitUplata, float limitIsplata)
        {
            UtilityClass.ProvjeriOIB(vlasnikOIB);
            string IBAN = UtilityClass.GenerirajNoviIBAN();
            TekuciRacun tekuciRacun = new(IBAN, 0.0f, 0.0f, vlasnikOIB, limitUplata, limitIsplata);

            return tekuciRacun;
        }

        public ITekuciRacun KreirajNoviRacunBezLimita(string vlasnikOIB)
        {
            UtilityClass.ProvjeriOIB(vlasnikOIB);
            string IBAN = UtilityClass.GenerirajNoviIBAN();
            TekuciRacunBezLimita tekuciRacun = new(IBAN, 0.0f, 0.0f, vlasnikOIB);

            return tekuciRacun;
        }


    }
}

