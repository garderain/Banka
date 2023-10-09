namespace Banka.Ziro_Racun
{
    public class ZiroRacun : IZiroRacun
    {
        private static float LIMITUPLATE = 10000;
        private static float LIMITISPLATE = 5000;
        public string? Ime { get; private set; }
        public string? Prezime { get; private set; }
        public float StanjeRacuna { get; private set; }
        public float RaspoloziviIznos { get; private set; }
        public float RezerviraniDio { get; private set; }
        public string? IBAN { get; private set; }

        private string? Oib { get; set; }
        private float LimitUplate { get; set; }
        private float LimitIsplate { get; set; }

        public ZiroRacun(string ime, string prezime, float stanjeRacuna, float rezerviraniDio, string OIB, string Iban)
        {
            Ime = ime;
            Prezime = prezime;
            Oib = OIB;
            IBAN = Iban;
            StanjeRacuna = stanjeRacuna;
            RaspoloziviIznos = stanjeRacuna - rezerviraniDio;
            LimitUplate = LIMITUPLATE;
            LimitIsplate = LIMITISPLATE;
        }

        public bool UplatiNovac(float IznosZaUplatu)
        {
            if (IznosZaUplatu <= LimitUplate)
            {
                StanjeRacuna += IznosZaUplatu;
                return true;
            }
            else { return false; }

        }
        public bool IsplatiNovac(float IznosZaIsplatu)
        {
            if (IznosZaIsplatu <= RaspoloziviIznos && IznosZaIsplatu <= LimitIsplate)
            {
                StanjeRacuna -= IznosZaIsplatu;
                return true;
            }
            else { return false; }
        }
    }
}
