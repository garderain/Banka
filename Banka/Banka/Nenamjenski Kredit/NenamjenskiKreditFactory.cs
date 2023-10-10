namespace Banka
{
    public class NenamjenskiKreditFactory : INenamjenskiKreditFactory
    {
        public INenamjenskiKredit KreirajNenamjenskiKredit(float glavnica, float kamatnaStopa, float rokOtplate, float mjesecnaPrimanja, float mjesecnaZaduzenja)
        {
            NenamjenskiKredit nenamjenskiKredit = new(glavnica, kamatnaStopa, rokOtplate);
            if ((nenamjenskiKredit.MjesecniAnuitet + mjesecnaZaduzenja) > mjesecnaPrimanja * UtilityClass.KreditniKoeficijent)
            { throw new InsufficientIncome("Nedovoljna mjesecna primanja!"); }
            else { return nenamjenskiKredit; }
        }


    }
}
