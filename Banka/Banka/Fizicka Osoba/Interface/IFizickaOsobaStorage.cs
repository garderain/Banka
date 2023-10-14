namespace Banka
{
    public interface IFizickaOsobaStorage
    {
        public void InicijalizirajStorage();
        public void SpremiStorage();
        public void AddFizickaOsoba(IFizickaOsoba fizickaOsoba);
        IFizickaOsoba? GetFizickaOsoba(string oib);
    }
}
