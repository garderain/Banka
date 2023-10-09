using System;
namespace Banka
{
	public class TekuciRacun: ITekuciRacun
	{
		private static readonly float LIMIT_UPLATA_DEFAULT = 50000.0f;
		private static readonly float LIMIT_ISPLATA_DEFAULT = 700.0f;

		public string IBAN { get; private set; }
		public float StanjeRacuna { get; private set; }
		public float RaspoloziviIznos { get; private set; }
		public float RezerviraniIznos { get; private set; }

		public float LimitUplata { get; private set; }
        public float LimitIsplata { get; private set; }

        private string VlasnikOIB;

		//Konstruktor za generiranje tekuceg racuna iz baze podataka
        public TekuciRacun(string iban, float stanjeRacuna, float rezerviraniIznos, string vlasnikOIB, float limitUplata, float limitIsplata)
		{
			IBAN = iban;
			StanjeRacuna = stanjeRacuna;
			RezerviraniIznos = rezerviraniIznos;
			RaspoloziviIznos = StanjeRacuna - RezerviraniIznos;
			VlasnikOIB = vlasnikOIB;
			LimitUplata = limitUplata;
			LimitIsplata = limitIsplata;
		}

        public TekuciRacun(string iban, float stanjeRacuna, float rezerviraniIznos, string vlasnikOIB)
        {
            IBAN = iban;
            StanjeRacuna = stanjeRacuna;
            RezerviraniIznos = rezerviraniIznos;
            RaspoloziviIznos = StanjeRacuna - RezerviraniIznos;
            VlasnikOIB = vlasnikOIB;
            LimitUplata = LIMIT_UPLATA_DEFAULT;
            LimitIsplata = LIMIT_ISPLATA_DEFAULT;
        }

        public bool UplatiNovac(float iznosZaUplatu)
		{
			if(iznosZaUplatu >= 0 && iznosZaUplatu <= LimitUplata)
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
			if(iznosZaIsplatu >= 0 && iznosZaIsplatu <= LimitIsplata && iznosZaIsplatu <= RaspoloziviIznos)
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

