namespace Banka.Tekuci_Racun
{
    public interface ITekuciRacunStorage
    {
        void InicijalizirajStorage();
        void SpremiStorage();
        void AddTekuciRacun(ITekuciRacun tekuciRacun);
        ITekuciRacun? GetTekuciRacun(string IBAN);
    }
}
