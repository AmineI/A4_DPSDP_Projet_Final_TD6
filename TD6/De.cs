using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public static class De
    {
        // We initialize the random generator
        private Random rnd = new Random();
        
        public static int RollDice()
        {
            // When we want to rill the dice we call random.Next(1,7) which return an interger between 1 and 7-1 
            return rnd.Next(1,7);
        }
    }
}
