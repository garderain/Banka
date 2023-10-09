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
            HashSet<VrstaRacuna> racuniZaIzradu = new();
            while (true)
            {
                Console.WriteLine("Zelite li kreirati:\n 1.Tekuci Racun \n2.Ziro Racun\n3.Izlaz");
                int izbor = Convert.ToInt32(Console.ReadLine());
                if (izbor == 1) { racuniZaIzradu.Add(VrstaRacuna.TEKUCI_RACUN); }
                else if (izbor == 2) { racuniZaIzradu.Add(VrstaRacuna.ZIRO_RACUN); }
                else if (izbor == 3) { break; }
                else { Console.WriteLine("Neispravan unos!"); }
            }




            if (ime == null || prezime == null || oib == null)
            {
                Console.WriteLine("Neispravan unos! Dovidenja!");
                return;
            }
            try
            {
                IFizickaOsoba fizickaOsoba = FactoryPool.DobaviInstancu().FizickaOsobaFactory.KreirajFizickuOsobu(ime, prezime, oib, racuniZaIzradu);
            }
            catch (InvalidAccountOption ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (HasZiroAccount ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                IFizickaOsoba fizickaOsoba = FactoryPool.DobaviInstancu().FizickaOsobaFactory.KreirajFizickuOsobu(ime, prezime, oib, racuniZaIzradu);
                fizickaOsoba.UplataNovca(VrstaRacuna.TEKUCI_RACUN, 200.0f);
                fizickaOsoba.IsplataNovca(VrstaRacuna.TEKUCI_RACUN, 150.0f);
            }
            //S popisom catch u kojima se nalaze specificni exceptioni definiramo koje exceptione zelimo uhvatiti i znamo razrijesiti
            catch (MalformedOibException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DuplicateOibException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Console.WriteLine(fizickaOsoba.TekuciRacun.StanjeRacuna);

            Console.ReadLine();

        }
    }
}

