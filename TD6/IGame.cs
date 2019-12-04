using System.Collections.Generic;

namespace TD6
{
    public interface IGame
    {
        IBoard Board { get; }
        IList<IPlayer> Players { get; }
        int CurrentTurn { get; }

        void InitializeBoard(IBoard board);
        void InitializeGame(IBoardCreator boardCreator, IPlayerListCreator playerListCreator);
        void InitializePlayerList(IList<IPlayer> players);
        void LaunchGame();
    }
}