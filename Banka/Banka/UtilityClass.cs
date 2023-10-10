using System.Text;

namespace Banka
{
    public class UtilityClass
    {
        public static readonly float KreditniKoeficijent = 0.3f;
        private static readonly string KOD_DRZAVA = "HR";
        private static readonly string KOD_BANKA = "1001005";
        List<string> ListaOIBa = new();

        public static void ProvjeriOIB(string oib)
        {
            foreach (char slovo in oib)
            {
                if (!Char.IsDigit(slovo)) { throw new MalformedOibException("Neispravan format OIB-a"); }
            }
            if (oib.Length != 11) { throw new MalformedOibException("Neispravan format OIB-a"); }
            if (ListaOIBa.Contains(oib))
            {
                throw new DuplicateOibException("OIB vec postoji");
            }


        }

        public static string GenerirajNoviIBAN()
        {
            StringBuilder kontrolniBrojevi = new();
            StringBuilder ostatak = new();
            List<string> iskoristeniIBANi = new();

            Random generator = new();
            kontrolniBrojevi.Append(generator.Next(0, 10));
            kontrolniBrojevi.Append(generator.Next(0, 10));
            string IBAN;
            do
            {
                for (int i = 0; i < 10; i++)
                {
                    ostatak.Append(generator.Next(0, 10));
                }
                IBAN = KOD_DRZAVA + kontrolniBrojevi.ToString() + KOD_BANKA + ostatak.ToString();


            } while (!iskoristeniIBANi.Contains(IBAN));
            iskoristeniIBANi.Add(IBAN);

            return IBAN;
        }

    }
}
