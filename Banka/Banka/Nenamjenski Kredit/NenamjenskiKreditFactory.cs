namespace Banka
{
    public class NenamjenskiKreditFactory : INenamjenskiKreditFactory
    {
        public INenamjenskiKredit KreirajNenamjenskiKredit(float glavnica, float kamatnaStopa, float rokOtplate, float mjesecnaPrimanja, float mjesecnaZaduzenja)
        {
            NenamjenskiKredit nenamjenskiKredit = new(glavnica, kamatnaStopa, rokOtplate);
            if ((nenamjenskiKredit.MjesecniAnuitet + mjesecnaZaduzenja) > mjesecnaPrimanja * UtilityClass.KreditniKoeficijent)
            { throw new InsufficientIncome("Nedovoljna mjesecna primanja!"); }
            return nenamjenskiKredit;
        }

        public INenamjenskiKredit KreirajKreditIzBaze(NenamjenskiKreditJson nenamjenskiKreditJson)
        {
            NenamjenskiKredit nenamjenskiKredit = new(nenamjenskiKreditJson.Glavnica, nenamjenskiKreditJson.KamatnaStopa, nenamjenskiKreditJson.RokOtplate, new Guid(nenamjenskiKreditJson.IdKredit));
            FactoryPool.DobaviInstancu().FizickaOsobaFactory.DodajKreditUListu(FizickaOsoba.listaNenamjenskihKredita, nenamjenskiKredit);
            return nenamjenskiKredit;

        }

        public List<INenamjenskiKredit> KreirajKrediteIzbaze(List<NenamjenskiKreditJson> nenamjenskikreditiJsonList)
        {
            List<INenamjenskiKredit> nenamjenskiKreditiList = new();
            foreach (NenamjenskiKreditJson nenamjenskiKreditJson in nenamjenskikreditiJsonList)
            {
                NenamjenskiKredit nenamjenskiKredit = new(nenamjenskiKreditJson.Glavnica, nenamjenskiKreditJson.KamatnaStopa, nenamjenskiKreditJson.RokOtplate, new Guid(nenamjenskiKreditJson.IdKredit));
                nenamjenskiKreditiList.Add(nenamjenskiKredit);
                FactoryPool.DobaviInstancu().FizickaOsobaFactory.DodajKreditUListu(FizickaOsoba.listaNenamjenskihKredita, nenamjenskiKredit);
            }
            return nenamjenskiKreditiList;
        }

        public List<NenamjenskiKreditJson> KreirajZapisNenamjenskihKreditaUBazu(List<INenamjenskiKredit> nenamjenskiKreditiList)
        {
            List<NenamjenskiKreditJson> nenamjenskiKreditiJsonList = new();
            foreach (INenamjenskiKredit nenamjenskiKredit in nenamjenskiKreditiList)
            {
                NenamjenskiKreditJson nenamjenskiKreditJson = new();
                nenamjenskiKreditJson.Glavnica = nenamjenskiKredit.Glavnica;
                nenamjenskiKreditJson.KamatnaStopa = nenamjenskiKredit.KamatnaStopa;
                nenamjenskiKreditJson.RokOtplate = nenamjenskiKredit.RokOtplate;
                nenamjenskiKreditJson.IdKredit = nenamjenskiKredit.IdKredit.ToString();
                nenamjenskiKreditiJsonList.Add(nenamjenskiKreditJson);
            }
            return nenamjenskiKreditiJsonList;
        }
    }
}
