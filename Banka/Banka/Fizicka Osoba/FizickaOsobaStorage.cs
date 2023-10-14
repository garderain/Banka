using Newtonsoft.Json;

namespace Banka
{
    public class FizickaOsobaStorage : IFizickaOsobaStorage
    {
        private static string PathToJsonFile = "C:\\Users\\Magdalena\\OneDrive\\Dokumenti\\GitHub\\Banka\\Banka\\Banka\\Fizicka Osoba\\FizickaOsobaJson.json";
        Dictionary<string, IFizickaOsoba> fizickeOsobe = new();
        public void InicijalizirajStorage()
        {
            string jsonFile = File.ReadAllText(PathToJsonFile);
            FizickeOsobeJson? fizickeOsobeJson = JsonConvert.DeserializeObject<FizickeOsobeJson>(jsonFile);
            if (fizickeOsobeJson == null)
            {
                throw new InvalidDataException("Greska u citanju baze tekucih racuna!");
            }

            List<IFizickaOsoba> fizickeOsobeList = FactoryPool.DobaviInstancu().FizickaOsobaFactory.KreirajFizickeOsobe(fizickeOsobeJson.fizickeOsobe);

            foreach (IFizickaOsoba fizickaOsoba in fizickeOsobeList)
            {
                Console.WriteLine(fizickaOsoba.Ime);
                fizickeOsobe.Add(fizickaOsoba.OIB, fizickaOsoba);
            }
        }
        public void SpremiStorage()
        {
            List<FizickaOsobaJson> fizickeOsobeJsonList = FactoryPool.DobaviInstancu().FizickaOsobaFactory.KreirajZapisFizickihOsoba(new List<IFizickaOsoba>(fizickeOsobe.Values));
            FizickeOsobeJson fizickeOsobeJson = new();
            fizickeOsobeJson.fizickeOsobe = fizickeOsobeJsonList;
            string jsonFile = JsonConvert.SerializeObject(fizickeOsobeJson);
            File.WriteAllText(PathToJsonFile, jsonFile);
        }

        public void AddFizickaOsoba(IFizickaOsoba fizickaOsoba)
        {
            if (fizickeOsobe.ContainsKey(fizickaOsoba.OIB))
            {
                throw new DuplicateOibException("Dodavanje nove osobe s postojecim OIB-om!");
            }
            fizickeOsobe.Add(fizickaOsoba.OIB, fizickaOsoba);
            return;
        }

        public IFizickaOsoba? GetFizickaOsoba(string oib)
        {
            if (fizickeOsobe.ContainsKey(oib))
            {
                return fizickeOsobe[oib];
            }
            return null;
        }
    }

}
