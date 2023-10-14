using Newtonsoft.Json;

namespace Banka
{
    public class ZiroRacunStorage
    {
        Dictionary<string, IZiroRacun> ziroRacuni = new();
        private static string pathToJsonFile = "C:\\Users\\Magdalena\\OneDrive\\Dokumenti\\GitHub\\Banka\\Banka\\Banka\\Ziro Racun\\ZiroRacuniJson.json";

        public void InicijalizirajStorage()
        {
            string jsonFile = File.ReadAllText(pathToJsonFile);
            ZiroRacuniJson? ziroRacuniJson = JsonConvert.DeserializeObject<ZiroRacuniJson>(jsonFile);
            if (ziroRacuniJson == null)
            {
                throw new InvalidDataException("Greska u citanju baze ziro racuna!");
            }
            List<IZiroRacun> listaZiroRacuna = FactoryPool.DobaviInstancu().ZiroRacunFactory.KreirajZiroRacuneIzBaze(ziroRacuniJson.ZiroRacuni);
            foreach (IZiroRacun ziroRacun in listaZiroRacuna)
            {
                ziroRacuni.Add(ziroRacun.IBAN, ziroRacun);
            }
        }

        public void SpremiStorage()
        {
            List<ZiroRacunJson> ziroRacuniJsonList = FactoryPool.DobaviInstancu().ZiroRacunFactory.KreirajZapisZiroRacuna(new List<IZiroRacun>(ziroRacuni.Values));
            ZiroRacuniJson ziroRacuniJson = new();
            ziroRacuniJson.ZiroRacuni = ziroRacuniJsonList;
            string jsonFile = JsonConvert.SerializeObject(ziroRacuniJson);
            File.WriteAllText(pathToJsonFile, jsonFile);
        }

        public void AddZiroRacun(IZiroRacun ziroRacun)
        {
            if (ziroRacuni.ContainsKey(ziroRacun.IBAN))
            {
                throw new DuplicateIbanException("Dodavanje novog tekuceg racuna s vec postojecim IBANom!");
            }
            ziroRacuni.Add(ziroRacun.IBAN, ziroRacun);
            return;
        }

        public IZiroRacun? GetZiroRacun(string IBAN)
        {
            if (ziroRacuni.ContainsKey(IBAN)) { return ziroRacuni[IBAN]; }
            else { return ziroRacuni[IBAN] = null; }
        }
    }
}
