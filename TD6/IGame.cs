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
        void InitializeGame(IView view, IBoardCreator boardCreator, IPlayerListCreator playerListCreator);
        void InitializePlayerList(IList<IPlayer> players);
        void LaunchGame();
        void ReplaceIPlayerInstances(IPlayer oldPlayer, IPlayer newPlayer);
    }
}