namespace Banka
{
    public interface INenamjenskiKreditFactory
    {
        INenamjenskiKredit KreirajNenamjenskiKredit(float glavnica, float kamatnaStopa, float rokOtplate, float mjesecnaPrimanja, float mjesecnaZaduzenja);

    }
}
