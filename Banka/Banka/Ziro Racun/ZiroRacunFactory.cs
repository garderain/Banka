namespace Banka
{
    public class ZiroRacunFactory : IZiroRacunFactory
    {

        public IZiroRacun KreirajZiroRacun()
        {
            string IBAN = UtilityClass.GenerirajNoviIBAN();
            ZiroRacun ziroRacun = new(0.0f, 0.0f, IBAN);
            return ziroRacun;
        }

        public IZiroRacun KreirajZiroRacunIzBaze(ZiroRacunJson ziroRacunjson)
        {
            ZiroRacun ziroRacun = new(ziroRacunjson.StanjeRacuna, ziroRacunjson.RezerviraniDio, ziroRacunjson.IBAN);
            return ziroRacun;
        }
        public List<IZiroRacun> KreirajZiroRacuneIzBaze(List<ZiroRacunJson> listaZiroRacuna)
        {
            List<IZiroRacun> ziroRacunLista = new();
            foreach (ZiroRacunJson ziroRacunJson in listaZiroRacuna)
            {
                ZiroRacun ziroRacun = new(ziroRacunJson.StanjeRacuna, ziroRacunJson.RezerviraniDio, ziroRacunJson.IBAN);
                ziroRacunLista.Add(ziroRacun);
            }
            return ziroRacunLista;
        }

        public List<ZiroRacunJson> KreirajZapisZiroRacuna(List<IZiroRacun> listaZiroRacuna)
        {
            List<ZiroRacunJson> listaZiroRacunaJson = new();
            ZiroRacunJson ziroRacunJson = new();
            foreach (IZiroRacun ziroRacun in listaZiroRacuna)
            {
                ziroRacunJson.StanjeRacuna = ziroRacun.StanjeRacuna;
                ziroRacunJson.RezerviraniDio = ziroRacun.RezerviraniDio;
                ziroRacunJson.RaspoloziviIznos = ziroRacun.RaspoloziviIznos;
                ziroRacunJson.LimitUplate = ziroRacun.LimitUplate;
                ziroRacunJson.LimitIsplate = ziroRacun.LimitUplate;
                listaZiroRacunaJson.Add(ziroRacunJson);
            }
            return listaZiroRacunaJson;
        }

    }
}
