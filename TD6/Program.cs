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
            do
            {
                //Todo : Creer un joueur l'aide d'une Factory de joueur ? Ils ont par défaut un certain montant d'argent notamment. 


                //TODO : Create a player creator user interface that asks the user for the needed information before creating the players 
                IPlayerListCreator InteractiveIPlayerListCreator = () =>
                {
                    return new List<IPlayer>() { new Player(1, "A", 200, Game.Instance) };
                };//Temporary sample list for testing.
                Game.Instance.InitializeGame(InternationalBoardBuilder.BuildDefaultBoard, InteractiveIPlayerListCreator);
                Game.Instance.LaunchGame();
                // When the game ends, the user can choose to launch a new one or not
            } while (UserInteraction.GetConfirmation("Do you want to start a new game ?"));
        }
    }
}
