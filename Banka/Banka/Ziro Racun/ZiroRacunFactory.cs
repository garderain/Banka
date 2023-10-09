using System.Text;

namespace Banka.Ziro_Racun
{
    public class ZiroRacunFactory : IZiroRacunFactory
    {
        private static readonly string KOD_DRZAVA = "HR";
        private static readonly string KOD_BANKA = "1001015";

        private List<string> iskoristeniIBANi = new();// Postoji li mogucnost da ne pravimo novu listu!
        private Dictionary<string, string> OibIban = new();
        public IZiroRacun KreirajZiroRacun(string ime, string prezime, string OIB)
        {
            string IBAN = GenerirajNoviIBAN();
            while (iskoristeniIBANi.Contains(IBAN))
            {
                IBAN = GenerirajNoviIBAN();
            }
            if (OibIban.ContainsKey(OIB)) { throw new HasZiroAccount("Osoba vec ima Ziro racun!"); }
            else
            {
                iskoristeniIBANi.Add(IBAN);
                OibIban.Add(OIB, IBAN);
            }
            ZiroRacun ziroRacun = new(ime, prezime, 0.0f, 0.0f, OIB, IBAN);
            return ziroRacun;

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
