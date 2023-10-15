using Banka.Tekuci_Racun;

namespace Banka
{
    public class StoragePool
    {
        private static StoragePool? storagePool;
        public IFizickaOsobaStorage FizickaOsobaStorage { get; }
        public ITekuciRacunStorage TekuciRacunStorage { get; }

        public IZiroRacunStorage ZiroRacunStorage { get; }
        public INenamjenskiKreditStorage NenamjenskiKreditStorage { get; }


        public StoragePool(BankaDbContext bankaDbContext)
        {
            TekuciRacunStorage = new TekuciRacunStorage(bankaDbContext);
            FizickaOsobaStorage = new FizickaOsobaStorage();
            ZiroRacunStorage = new ZiroRacunStorage();
            NenamjenskiKreditStorage = new NenamjenskiKreditStorage();
        }

        public void InicijalizirajStorage()
        {
            TekuciRacunStorage.InicijalizirajStorage();
            FizickaOsobaStorage.InicijalizirajStorage();
            ZiroRacunStorage.InicijalizirajStorage();
            NenamjenskiKreditStorage.InicijalizirajStorage();
        }
        public void SpremiStorage()
        {
            TekuciRacunStorage.SpremiStorage();
            FizickaOsobaStorage.SpremiStorage();
            ZiroRacunStorage.SpremiStorage();
            NenamjenskiKreditStorage.SpremiStorage();
        }
        public static StoragePool GetStoragePool(BankaDbContext? bankaDbContext = null)
        {
            storagePool ??= new StoragePool(bankaDbContext);
            return storagePool;
        }
    }
}
