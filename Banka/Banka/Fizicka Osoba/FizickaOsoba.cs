﻿namespace Banka
{
    public class FizickaOsoba : IFizickaOsoba
    {
        public string Ime { get; private set; }
        public string Prezime { get; private set; }
        public string OIB { get; private set; }
        public ITekuciRacun? TekuciRacun { get; private set; }
        public IZiroRacun? ZiroRacun { get; private set; }

        public FizickaOsoba(string ime, string prezime, string oib, ITekuciRacun? tekuciRacun, IZiroRacun? ziroRacun)
        {
            Ime = ime;
            Prezime = prezime;
            OIB = oib;
            TekuciRacun = tekuciRacun;
            ZiroRacun = ziroRacun;
        }

        public bool IsplataNovca(VrstaRacuna vrstaRacuna, float iznos)
        {
            switch (vrstaRacuna)
            {
                case VrstaRacuna.TEKUCI_RACUN:
                    return TekuciRacun.PodigniNovac(iznos);
                case VrstaRacuna.ZIRO_RACUN:
                    return ZiroRacun.UplatiNovac(iznos);
                default:
                    return false;
            }
        }

        public bool UplataNovca(VrstaRacuna vrstaRacuna, float iznos)
        {
            switch (vrstaRacuna)
            {
                case VrstaRacuna.TEKUCI_RACUN:
                    return TekuciRacun.UplatiNovac(iznos);
                case VrstaRacuna.ZIRO_RACUN:
                    return ZiroRacun.UplatiNovac(iznos);
                default:
                    return false;
            }
        }
    }

}