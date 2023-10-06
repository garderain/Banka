using System;
namespace Banka
{
	public class AppMain
	{
        static void Main(string[] args)
        {
			ITekuciRacunFactory tekuciRacunFactory = FactoryPool.DobaviInstancu().TekuciRacunFactory;

			Console.WriteLine("Unesite ime osobe: ");
			string? ime = Console.ReadLine();
			Console.WriteLine("Unesite prezime osobe: ");
			string? prezime = Console.ReadLine();
			Console.WriteLine("Unesite OIB osobe: ");
			string? oib = Console.ReadLine();

			if(ime == null || prezime == null || oib == null)
			{
				Console.WriteLine("Neispravan unos! Dovidenja!");
				return;
			}

			FizickaOsoba fizickaOsoba = new FizickaOsoba(ime, prezime, oib, tekuciRacunFactory.KreirajNoviRacun(oib));

			fizickaOsoba.UplataNovca(VrstaRacuna.TEKUCI_RACUN, 200.0f);
			fizickaOsoba.IsplataNovca(VrstaRacuna.TEKUCI_RACUN, 150.0f);

			Console.WriteLine(fizickaOsoba.TekuciRacun.StanjeRacuna);

			Console.ReadLine();
		}
	}
}

