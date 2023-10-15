namespace Banka
{
    public class FizickeOsobeJson
    {
        public List<FizickaOsobaJson> fizickeOsobe { get; set; }
        public FizickeOsobeJson()
        {
            fizickeOsobe = new();
        }
    }

    public class FizickaOsobaJson
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string OIB { get; set; }
        public string? TekuciRacunIBAN { get; set; }
        public string? ZiroRacunIBAN { get; set; }
        public List<string> ListaNenamjenskihKreditaIds { get; set; }


        public FizickaOsobaJson()
        {
            Ime = string.Empty;
            Prezime = string.Empty;
            OIB = string.Empty;
            TekuciRacunIBAN = null;
            ZiroRacunIBAN = null;
            ListaNenamjenskihKreditaIds = new();
        }
    }
}
