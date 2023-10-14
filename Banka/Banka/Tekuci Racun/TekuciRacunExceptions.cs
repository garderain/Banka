namespace Banka
{
    public class DuplicateIbanException : Exception
    {
        public DuplicateIbanException(string message) : base(message) { }
    }

    public class NoTekuciRacunWithIBAN : Exception
    {
        public NoTekuciRacunWithIBAN(string IBAN) : base("No Tekuci Racun with IBAN: " + IBAN + " found!") { }
    }
}
