using System;
namespace Banka
{
    public class TekuciRacunBezLimita: ITekuciRacun
    {
        public string IBAN { get; private set; }
        public float StanjeRacuna { get; private set; }
        public float RaspoloziviIznos { get; private set; }
        public float RezerviraniIznos { get; private set; }

        private string VlasnikOIB;

        //Konstruktor za generiranje tekuceg racuna iz baze podataka
        public TekuciRacunBezLimita(string IBAN, float stanjeRacuna, float rezerviraniIznos, string vlasnikOIB)
        {
            this.IBAN = IBAN;
            StanjeRacuna = stanjeRacuna;
            RezerviraniIznos = rezerviraniIznos;
            RaspoloziviIznos = StanjeRacuna - RezerviraniIznos;
            VlasnikOIB = vlasnikOIB;
        }

        public bool UplatiNovac(float iznosZaUplatu)
        {
            if (iznosZaUplatu >= 0)
            {
                StanjeRacuna += iznosZaUplatu;
                RaspoloziviIznos = StanjeRacuna - RezerviraniIznos;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PodigniNovac(float iznosZaIsplatu)
        {
            if (iznosZaIsplatu >= 0 && iznosZaIsplatu <= RaspoloziviIznos)
            {
                StanjeRacuna -= iznosZaIsplatu;
                RaspoloziviIznos = StanjeRacuna - RezerviraniIznos;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

