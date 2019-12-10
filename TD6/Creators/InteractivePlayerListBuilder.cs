using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    static class InteractivePlayerListBuilder
    {
        public static IList<IPlayer> AskForPlayerList(IGame game, IView view)
        {
            IList<IPlayer> players = new List<IPlayer>();
            //Add players
            do
            {
                view.ClearView();
                view.DisplayMessage($"Player {players.Count + 1} :");
                string playerName = view.GetEnteredString("What is your name ?");
                Player player = PlayerFactory.CreatePlayer(playerName, game);
                players.Add(player);
                view.DisplayMessage($"You are the player number {players.Count}, and displayed as the {player.DisplayCharacter} symbol. You start with {player.Money}$.\n");
                view.GetConfirmation("Do you want to continue ?");
            } while (players.Count < 2 || view.GetConfirmation("Do you want to add another player ?"));

            return players;

        }
    }
}
