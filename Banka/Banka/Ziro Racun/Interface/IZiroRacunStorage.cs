namespace Banka
{
    public interface IZiroRacunStorage
    {
        void InicijalizirajStorage();
        void SpremiStorage();
        void AddZiroRacun(IZiroRacun ziroRacun);
        IZiroRacun? GetZiroRacun(string IBAN);
        bool IbanPostoji(string IBAN);
    }
}
