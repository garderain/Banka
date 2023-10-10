namespace Banka
{
    public class ZiroRacunFactory : IZiroRacunFactory
    {
        private Dictionary<string, string> OibIban = new();
        public IZiroRacun KreirajZiroRacun(string OIB)
        {
            UtilityClass.ProvjeriOIB(OIB);
            string IBAN = UtilityClass.GenerirajNoviIBAN();
            if (OibIban.ContainsKey(OIB)) { throw new HasZiroAccount("Osoba vec ima Ziro racun!"); }
            else
            {
                OibIban.Add(OIB, IBAN);
            }
            ZiroRacun ziroRacun = new(0.0f, 0.0f, IBAN);
            return ziroRacun;

        }



    }
}
