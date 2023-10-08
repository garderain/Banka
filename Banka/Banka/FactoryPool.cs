﻿namespace Banka
{
    //Primjer Singleton klase
    public class FactoryPool
    {
        //Sve tvornice -> definira vanjsko sucelje prema ostatku sustava
        public ITekuciRacunFactory TekuciRacunFactory { get; }
        public IFizickaOsobaFactory FizickaOsobaFactory { get; }

        private static FactoryPool? factoryPool; //Instanca klase FactoryPool

        private FactoryPool()
        {
            TekuciRacunFactory = new TekuciRacunFactory(); //Ovdje odlucujemo koju implementaciju tvornice za TekuciRacun koristimo
            FizickaOsobaFactory = new FizickaOsobaFactory();
        }

        public static FactoryPool DobaviInstancu()
        {
            factoryPool ??= new FactoryPool();

            return factoryPool;
        }
    }
}

