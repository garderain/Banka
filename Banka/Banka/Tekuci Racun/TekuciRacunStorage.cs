using Banka.Tekuci_Racun;

namespace Banka
{
    public class TekuciRacunStorage : ITekuciRacunStorage
    {
        private readonly BankaDbContext BankaDbContext;

        public TekuciRacunStorage(BankaDbContext bankaDbContext)
        {
            BankaDbContext = bankaDbContext;
        }

        public void InicijalizirajStorage()
        {

        }

        public void SpremiStorage()
        {

        }

        public void AddTekuciRacun(ITekuciRacun tekuciRacun)
        {
            BankaDbContext.Add(tekuciRacun);
        }

        public ITekuciRacun? GetTekuciRacun(string IBAN)
        {
            return null;
        }

        public bool IbanPostoji(string IBAN)
        {
            return false;
        }

    }
}
