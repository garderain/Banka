using Newtonsoft.Json;

namespace Banka
{
    public class NenamjenskiKreditStorage : INenamjenskiKreditStorage
    {
        private static string pathToJsonFile = "C:\\Users\\Magdalena\\OneDrive\\Dokumenti\\GitHub\\Banka\\Banka\\Banka\\Nenamjenski Kredit\\NenamjenskiKreditiJson.json";
        Dictionary<Guid, INenamjenskiKredit> nenamjenskiKrediti = new();

        public void InicijalizirajStorage()
        {
            string JsonFile = File.ReadAllText(pathToJsonFile);
            NenamjenskiKreditiJson? nenamjenskiKreditiJson = JsonConvert.DeserializeObject<NenamjenskiKreditiJson>(pathToJsonFile);

            List<INenamjenskiKredit> nenamjenskiKreditList = FactoryPool.DobaviInstancu().NenamjenskiKreditFactory.KreirajKrediteIzbaze(nenamjenskiKreditiJson.nenamjenskiKrediti);
            foreach (INenamjenskiKredit nenamjenskiKredit in nenamjenskiKreditList)
            {
                nenamjenskiKrediti.Add(nenamjenskiKredit.IdKredit, nenamjenskiKredit);
            }
        }

        public void SpremiStorage()
        {
            List<NenamjenskiKreditJson> nenamjenskiKreditiJsonList = FactoryPool.DobaviInstancu().NenamjenskiKreditFactory.KreirajZapisNenamjenskihKreditaUBazu(new List<INenamjenskiKredit>(nenamjenskiKrediti.Values));
            NenamjenskiKreditiJson nenamjenskiKreditJson = new();
            nenamjenskiKreditJson.nenamjenskiKrediti = nenamjenskiKreditiJsonList;
            string jsonFile = JsonConvert.SerializeObject(nenamjenskiKreditJson);
            File.WriteAllText(pathToJsonFile, jsonFile);
        }

        public INenamjenskiKredit? GetNenamjenskiKredit(Guid IdKredita)
        {
            if (nenamjenskiKrediti.ContainsKey(IdKredita)) { return nenamjenskiKrediti[IdKredita]; }
            else { return null; }
        }

        public void AddNenamjenskiKredit(INenamjenskiKredit nenamjenskiKredit)
        {
            nenamjenskiKrediti.Add(nenamjenskiKredit.IdKredit, nenamjenskiKredit);
            return;
        }
    }
}
