using Banka.Tekuci_Racun;

namespace Banka
{
    public class StoragePool
    {
        private static StoragePool? storagePool;
        public IFizickaOsobaStorage FizickaOsobaStorage { get; }
        public ITekuciRacunStorage TekuciRacunStorage { get; }

        public IZiroRacunStorage ZiroRacunStorage { get; }


        public StoragePool()
        {
            TekuciRacunStorage = new TekuciRacunStorage();
            FizickaOsobaStorage = new FizickaOsobaStorage();
            ZiroRacunStorage = new ZiroRacunStorage
        }

        public void InicijalizirajStorage()
        {
            TekuciRacunStorage.InicijalizirajStorage();
            FizickaOsobaStorage.InicijalizirajStorage();
            ZiroRacunStorage.InicijalizirajStorage();
        }

        public static StoragePool GetStoragePool()
        {
            storagePool ??= new StoragePool();
            return storagePool;
        }
    }
}
