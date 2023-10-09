using System.Text;

namespace Banka
{
    public class TekuciRacunFactory : ITekuciRacunFactory
    {
        private static readonly string KOD_DRZAVA = "HR";
        private static readonly string KOD_BANKA = "1001005";

        private List<string> iskoristeniIBANi = new();

        public ITekuciRacun KreirajNoviRacun(string vlasnikOIB)
        {
            string IBAN = GenerirajNoviIBAN();
            while (iskoristeniIBANi.Contains(IBAN))
            {
                IBAN = GenerirajNoviIBAN();
            }

            iskoristeniIBANi.Add(IBAN);

            TekuciRacun tekuciRacun = new(IBAN, 0.0f, 0.0f, vlasnikOIB);

            return tekuciRacun;
        }

        public ITekuciRacun KreirajNoviRacun(string vlasnikOIB, float limitUplata, float limitIsplata)
        {
            string IBAN = GenerirajNoviIBAN();
            while (iskoristeniIBANi.Contains(IBAN))
            {
                IBAN = GenerirajNoviIBAN();
            }

            TekuciRacun tekuciRacun = new(IBAN, 0.0f, 0.0f, vlasnikOIB, limitUplata, limitIsplata);

            return tekuciRacun;
        }

        public ITekuciRacun KreirajNoviRacunBezLimita(string vlasnikOIB)
        {
            string IBAN = GenerirajNoviIBAN();
            while (iskoristeniIBANi.Contains(IBAN))
            {
                IBAN = GenerirajNoviIBAN();
            }

            TekuciRacunBezLimita tekuciRacun = new(IBAN, 0.0f, 0.0f, vlasnikOIB);

            return tekuciRacun;
        }

        private string GenerirajNoviIBAN()
        {
            StringBuilder kontrolniBrojevi = new();
            StringBuilder ostatak = new();

            Random generator = new();
            kontrolniBrojevi.Append(generator.Next(0, 10));
            kontrolniBrojevi.Append(generator.Next(0, 10));

            for (int i = 0; i < 10; i++)
            {
                ostatak.Append(generator.Next(0, 10));
            }

            return KOD_DRZAVA + kontrolniBrojevi.ToString() + KOD_BANKA + ostatak.ToString();
        }
    }
}

