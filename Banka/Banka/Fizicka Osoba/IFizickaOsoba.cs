namespace Banka
{
    public interface IFizickaOsoba
    {
        string Ime { get; }
        string Prezime { get; }
        bool IsplataNovca(VrstaRacuna vrstaRacuna, float iznos);
        bool UplataNovca(VrstaRacuna vrstaRacuna, float iznos);
        float KreditnaSposobnost(float mjesecnaPrimanja);
    }
}
