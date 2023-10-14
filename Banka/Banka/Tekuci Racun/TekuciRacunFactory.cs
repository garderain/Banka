namespace Banka
{
    public class TekuciRacunFactory : ITekuciRacunFactory
    {
        public ITekuciRacun KreirajPostojeciRacun(string IBAN, float stanjeRacuna, float rezerviraniIznos, float limitUplata, float limitIsplata)
        {
            TekuciRacun tekuciRacun = new(IBAN, stanjeRacuna, rezerviraniIznos, limitUplata, limitIsplata);

            return tekuciRacun;
        }
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

        public ITekuciRacun KreirajTekuciracunIzBaze(TekuciRacunJson tekuciRacunJson)
        {
            ITekuciRacun? tekuci_Racun = null;
            tekuci_Racun = StoragePool.GetStoragePool().TekuciRacunStorage.GetTekuciRacun(tekuciRacunJson.IBAN);
            if (tekuci_Racun == null)
            {
                throw new NoTekuciRacunWithIBAN(tekuciRacunJson.IBAN);
            }
            TekuciRacun tekuciRacun = new(tekuciRacunJson.IBAN, tekuciRacunJson.StanjeRacuna, tekuciRacunJson.RezerviraniIznos);
            return tekuciRacun;
        }

        public List<ITekuciRacun> KreirajTekuceRacune(List<TekuciRacunJson> tekuciRacuniJson)
        {
            List<ITekuciRacun> listaTekucihRacuna = new();
            foreach (TekuciRacunJson tekuciRacun in tekuciRacuniJson)
            {
                ITekuciRacun tekuci_Racun = StoragePool.GetStoragePool().TekuciRacunStorage.GetTekuciRacun(tekuciRacun.IBAN);
                listaTekucihRacuna.Add(tekuci_Racun);
            }
            return listaTekucihRacuna;
        }

        public List<TekuciRacunJson> KreirajZapisTekucihRacuna(List<ITekuciRacun> listaTekucihRacuna)
        {
            List<TekuciRacunJson> tekuciRacuniJsonList = new();
            foreach (ITekuciRacun tekuciRacun in listaTekucihRacuna)
            {
                TekuciRacunJson tekuciRacunJson = new();
                tekuciRacunJson.IBAN = tekuciRacun.IBAN;
                tekuciRacunJson.RezerviraniIznos = tekuciRacun.RezerviraniIznos;
                tekuciRacunJson.StanjeRacuna = tekuciRacun.StanjeRacuna;
                tekuciRacunJson.LimitIsplata = tekuciRacun.LimitIsplata;
                tekuciRacunJson.LimitUplata = tekuciRacun.LimitUplata;
                tekuciRacuniJsonList.Add(tekuciRacunJson);
            }
            return tekuciRacuniJsonList;
        }


    }
}

