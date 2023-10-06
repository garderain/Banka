using System;
namespace Banka
{
	//Primjer Singleton klase
	public class FactoryPool
	{
		//Sve tvornice -> definira vanjsko sucelje prema ostatku sustava
		public ITekuciRacunFactory TekuciRacunFactory { get; }

		private static FactoryPool? factoryPool; //Instanca klase FactoryPool

        private FactoryPool()
		{
			TekuciRacunFactory = new TekuciRacunFactory(); //Ovdje odlucujemo koju implementaciju tvornice za TekuciRacun koristimo
		}

		public static FactoryPool DobaviInstancu()
		{
			factoryPool ??= new FactoryPool();

			return factoryPool;
		}
	}
}

