namespace Banka
{
    public interface INenamjenskiKreditFactory
    {
        INenamjenskiKredit KreirajNenamjenskiKredit(float glavnica, float kamatnaStopa, float rokOtplate, float mjesecnaPrimanja, float mjesecnaZaduzenja);
        public List<NenamjenskiKreditJson> KreirajZapisNenamjenskihKreditaUBazu(List<INenamjenskiKredit> nenamjenskiKreditiList);
        public List<INenamjenskiKredit> KreirajKrediteIzbaze(List<NenamjenskiKreditJson> nenamjenskikreditiJsonList);
        public INenamjenskiKredit KreirajKreditIzBaze(NenamjenskiKreditJson nenamjenskiKreditJson);

    }
}
