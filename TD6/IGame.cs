using System.Collections.Generic;

namespace TD6
{
    public interface IGame
    {
        IBoard Board { get; }
        List<IPlayer> Players { get; }
        int CurrentTurn { get; }
        IView View { get; set; }
        void InitializeBoard(IBoard board);
        void InitializePlayerList(IList<IPlayer> players);
        void InitializeGame(IView view, IBoardCreator boardCreator, IPlayerListCreator playerListCreator);
        void LaunchGame();
        void ReplaceIPlayerInstances(IPlayer oldPlayer, IPlayer newPlayer);
    }
}