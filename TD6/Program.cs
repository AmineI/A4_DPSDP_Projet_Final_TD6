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
            IView view = new ConsoleView();
            view.DisplayMessage("Welcome to the Monopoly");
            view.Pause();
            do
            {
                IPlayerListCreator InteractiveIPlayerListCreator = () => InteractivePlayerListBuilder.AskForPlayerList(Game.Instance, view);

                Game.Instance.InitializeGame(view, InternationalBoardBuilder.BuildDefaultBoard, InteractiveIPlayerListCreator);
                Game.Instance.LaunchGame();
                // When the game ends, the user can choose to launch a new one or not
            } while (view.GetConfirmation("Do you want to start a new game ?"));
        }
    }
}
