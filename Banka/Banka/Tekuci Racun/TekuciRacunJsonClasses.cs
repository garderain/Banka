namespace Banka
{

    public class TekuciRacuniJson
    {
        public List<TekuciRacunJson> TekuciRacuni { get; set; }
        public TekuciRacuniJson()
        {
            TekuciRacuni = new();
        }
    }

    public class TekuciRacunJson
    {
        public string IBAN { get; set; }
        public float StanjeRacuna { get; set; }
        public float RezerviraniIznos { get; set; }
        public float LimitUplata { get; set; }
        public float LimitIsplata { get; set; }
        public TekuciRacunJson()
        {
            IBAN = string.Empty;
            StanjeRacuna = 0;
            RezerviraniIznos = 0;
            LimitUplata = 0;
            LimitIsplata = 0;
        }
    }
}
