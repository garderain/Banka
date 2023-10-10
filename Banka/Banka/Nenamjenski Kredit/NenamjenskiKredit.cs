namespace Banka
{
    public class NenamjenskiKredit : INenamjenskiKredit
    {
        public float Glavnica { get; private set; }
        public float KamatnaStopa { get; private set; }
        public float RokOtplate { get; private set; }
        public float UkupnaKamata { get; private set; }
        public float UkupanIznosZaOtplatu { get; private set; }
        public float MjesecniAnuitet { get; private set; }



        public NenamjenskiKredit(float glavnica, float kamatnaStopa, float rokOtplate)
        {
            Glavnica = glavnica;
            KamatnaStopa = kamatnaStopa;
            RokOtplate = rokOtplate;
            IzracunUkupneKamate();
            IznosZaOtplatu();
            IznosMjesecnogAnuiteta();
        }
        private void IznosMjesecnogAnuiteta()
        {
            MjesecniAnuitet = UkupanIznosZaOtplatu / (RokOtplate * 12);
            return;
        }
        public bool UplatiRatu(float iznosZaUplatu)
        {
            if (iznosZaUplatu <= UkupanIznosZaOtplatu)
            { UkupanIznosZaOtplatu -= iznosZaUplatu; return true; }
            else { return false; }
        }
        private void IzracunUkupneKamate()
        {
            UkupnaKamata = (KamatnaStopa / 100) * Glavnica * RokOtplate; return;
        }
        private void IznosZaOtplatu()
        {
            UkupanIznosZaOtplatu = Glavnica + UkupnaKamata;
            return;
        }
    }
}
