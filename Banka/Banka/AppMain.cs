namespace Banka
{
    public class AppMain
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Unesite ime osobe: ");
            string? ime = Console.ReadLine();
            Console.WriteLine("Unesite prezime osobe: ");
            string? prezime = Console.ReadLine();
            Console.WriteLine("Unesite OIB osobe: ");
            string? oib = Console.ReadLine();

            if (ime == null || prezime == null || oib == null)
            {
                Console.WriteLine("Neispravan unos! Dovidenja!");
                return;
            }


            try
            {
                IFizickaOsoba fizickaOsoba = FactoryPool.DobaviInstancu().FizickaOsobaFactory.KreirajFizickuOsobu(ime, prezime, oib);
                fizickaOsoba.UplataNovca(VrstaRacuna.TEKUCI_RACUN, 200.0f);
                fizickaOsoba.IsplataNovca(VrstaRacuna.TEKUCI_RACUN, 150.0f);
            }
            //S popisom catch u kojima se nalaze specificni exceptioni definiramo koje exceptione zelimo uhvatiti i znamo razrijesiti
            catch (MalformedOibException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(DuplicateOibException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            //Console.WriteLine(fizickaOsoba.TekuciRacun.StanjeRacuna);

            Console.ReadLine();
        }
    }
}

