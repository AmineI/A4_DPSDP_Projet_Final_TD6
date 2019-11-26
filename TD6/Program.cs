using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TD6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Monopoly");
            do {
                Game.Instance.LaunchGame();
                // When the game ends, the user can choose to launch a new one or not
            } while (UserInteraction.GetConfirmation("Do you want to start a new game ?"));
        }
    }
}
