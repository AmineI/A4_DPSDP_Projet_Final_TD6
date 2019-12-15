using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public static class Dice
    {
        // We initialize the random generator
        private static Random randomGenerator = new Random();


        /// <summary>
        /// Roll the dice
        /// </summary>
        /// <returns>A random integer between 1 and 6 corresponding to the value of the dice</returns>
        public static int RollDice()
        {
            // When we want to roll the dice we call random.Next(1,7) which return an interger between 1 and 7-1 
            return randomGenerator.Next(1,7);
        }
    }
}
