namespace Banka
{
    public class ZiroRacun : IZiroRacun
    {
        private static float LIMITUPLATE = 10000;
        private static float LIMITISPLATE = 5000;
        public float StanjeRacuna { get; private set; }
        public float RaspoloziviIznos { get; private set; }
        public float RezerviraniDio { get; private set; }
        public string? IBAN { get; private set; }

        public float LimitUplate { get; set; }
        public float LimitIsplate { get; set; }

        public ZiroRacun(float stanjeRacuna, float rezerviraniDio, string Iban)
        {
            IBAN = Iban;
            StanjeRacuna = stanjeRacuna;
            RaspoloziviIznos = stanjeRacuna - rezerviraniDio;
            LimitUplate = LIMITUPLATE;
            LimitIsplate = LIMITISPLATE;
        }

        public bool UplatiNovac(float iznosZaUplatu)
        {
            if (iznosZaUplatu <= LimitUplate)
            {
                StanjeRacuna += iznosZaUplatu;
                return true;
            }
            else { return false; }

        }
        public bool IsplatiNovac(float iznosZaIsplatu)
        {
            if (iznosZaIsplatu <= RaspoloziviIznos && iznosZaIsplatu <= LimitIsplate)
            {
                StanjeRacuna -= iznosZaIsplatu;
                return true;
            }
            else { return false; }
        }
    }
}
