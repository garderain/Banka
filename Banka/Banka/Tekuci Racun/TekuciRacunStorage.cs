using Banka.Tekuci_Racun;
using Newtonsoft.Json;

namespace Banka
{
    public class TekuciRacunStorage : ITekuciRacunStorage
    {
        private static string pathToStorageFile = "C:\\Users\\Magdalena\\OneDrive\\Dokumenti\\GitHub\\Banka\\Banka\\Banka\\TekuciRacuni.json";
        Dictionary<string, ITekuciRacun> tekuciRacuni = new();

        public void InicijalizirajStorage()
        {
            string jsonFile = File.ReadAllText(pathToStorageFile);
            TekuciRacuniJson? tekuciRacuniJson = JsonConvert.DeserializeObject<TekuciRacuniJson>(jsonFile);

            if (tekuciRacuniJson == null)
            {
                throw new InvalidDataException("Greska u citanju baze tekucih racuna!");
            }
            List<ITekuciRacun> listaTekucihRacuna = FactoryPool.DobaviInstancu().TekuciRacunFactory.KreirajTekuceRacune(tekuciRacuniJson.TekuciRacuni);
            foreach (ITekuciRacun tekuciRacun in listaTekucihRacuna)
            {
                tekuciRacuni.Add(tekuciRacun.IBAN, tekuciRacun);
            }
        }
        public void SpremiStorage()
        {
            List<TekuciRacunJson> tekuciRacuniJsonList = FactoryPool.DobaviInstancu().TekuciRacunFactory.KreirajZapisTekucihRacuna(new List<ITekuciRacun>(tekuciRacuni.Values));

            TekuciRacuniJson tekuciRacuniJson = new();
            tekuciRacuniJson.TekuciRacuni = tekuciRacuniJsonList;
            string jsonFile = JsonConvert.SerializeObject(tekuciRacuniJson);
            File.WriteAllText(pathToStorageFile, jsonFile);
        }

        public void AddTekuciRacun(ITekuciRacun tekuciRacun)
        {
            if (tekuciRacuni.ContainsKey(tekuciRacun.IBAN))
            {
                throw new DuplicateIbanException("Dodavanje novog tekuceg racuna s vec postojecim IBANom!");
            }
            tekuciRacuni.Add(tekuciRacun.IBAN, tekuciRacun);
            return;
        }

        public ITekuciRacun? GetTekuciRacun(string IBAN)
        {
            if (tekuciRacuni.ContainsKey(IBAN))
            {
                return tekuciRacuni[IBAN];
            }
            return null;
        }

    }
}
