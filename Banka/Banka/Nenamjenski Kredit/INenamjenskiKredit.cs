namespace Banka
{
    public interface INenamjenskiKredit
    {
        float RokOtplate { get; }
        float Glavnica { get; }
        float KamatnaStopa { get; }
        float UkupnaKamata { get; }
        float UkupanIznosZaOtplatu { get; }
        float MjesecniAnuitet { get; }



        bool UplatiRatu(float iznosZaUplatu);

    }
}
