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
                //Lorsque la partie se termine, l'utilisateur peut choisir s'il en lance une nouvelle ou pas
            } while (UserInteraction.GetConfirmation("Do you want to start a new game ?"));
        }
    }
}
