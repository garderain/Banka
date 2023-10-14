namespace Banka
{
    public interface IZiroRacunFactory
    {
        IZiroRacun KreirajZiroRacun();
        List<IZiroRacun> KreirajZiroRacuneIzBaze(List<ZiroRacunJson> listaZiroRacuna);
        List<ZiroRacunJson> KreirajZapisZiroRacuna(List<IZiroRacun> listaZiroRacuna);
        IZiroRacun KreirajZiroRacunIzBaze(ZiroRacunJson ziroRacunjson);


    }
}
