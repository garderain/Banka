namespace Banka
{
    public class ZiroRacuniJson
    {
        public List<ZiroRacunJson> ZiroRacuni { get; set; }
        public ZiroRacuniJson()
        {
            ZiroRacuni = new();
        }
    }

    public class ZiroRacunJson
    {
        public float StanjeRacuna { get; set; }
        public float RaspoloziviIznos { get; set; }
        public float RezerviraniDio { get; set; }
        public string? IBAN { get; set; }

        public float LimitUplate { get; set; }
        public float LimitIsplate { get; set; }
    }
}
