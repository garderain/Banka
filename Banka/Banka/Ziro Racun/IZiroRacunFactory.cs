namespace Banka
{
    public interface IZiroRacunFactory
    {
        IZiroRacun KreirajZiroRacun(string OIB);
        List<IZiroRacun> KreirajZiroRacuneIzBaze(List<ZiroRacunJson> listaZiroRacuna);
        List<ZiroRacunJson> KreirajZapisZiroRacuna(List<IZiroRacun> listaZiroRacuna)


    }
}
