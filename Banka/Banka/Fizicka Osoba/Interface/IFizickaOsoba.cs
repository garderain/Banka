namespace Banka
{
    public interface IFizickaOsoba
    {
        string Ime { get; }
        string Prezime { get; }
        string OIB { get; }
        bool IsplataNovca(VrstaRacuna vrstaRacuna, float iznos);
        bool UplataNovca(VrstaRacuna vrstaRacuna, float iznos);
        float KreditnaSposobnost(float mjesecnaPrimanja);
        static List<INenamjenskiKredit> listaNenamjenskihKredita { get; set; }

    }
}
