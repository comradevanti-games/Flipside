using System;

namespace Foxy.Flipside
{

    public class Rng
    {

        private readonly Random rand;


        public Rng(int seed) =>
            rand = new Random(seed);


        public int InRange(int min, int max) => 
            rand.Next(min, max + 1);

    }

}