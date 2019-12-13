using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TD6
{
    //TODO : Move these methods to the board builder and player factory/builder when it will be done
    public delegate IBoard IBoardCreator();
    public delegate IList<IPlayer> IPlayerListCreator();
    public class Game : IGame
    {
        private IBoard board = new Board();
        public IBoard Board { get => board; }
        private List<IPlayer> players;
        public List<IPlayer> Players { get => players; }
        private int currentTurn = 0;
        public int CurrentTurn { get => currentTurn; }

        public IView View { get; set; }



        /// <summary>
        /// We store the unique instance of the Game in a static variable
        /// </summary>
        static private Game game = new Game();

        /// <summary>
        /// We allow the user to access our unique Game instance
        /// </summary>
        public static Game Instance
        {
            get => game;
        }

        /// <summary>
        /// The constructor is private to ensure the uniqueness of the Game.
        /// </summary>
        private Game()
        {
        }

        public void InitializeBoard(IBoard board)
        {
            this.board = board;
        }
        public void InitializePlayerList(IList<IPlayer> players)
        {
            this.players = players.ToList<IPlayer>();
        }

        /// <summary>
        /// Initialize both the game board and the players thanks to the delegates method given.
        /// Is optimized to use two threads : one  taking care of the board, and one taking care of the player list.
        /// </summary>
        public void InitializeGame(IView view, IBoardCreator boardCreator, IPlayerListCreator playerListCreator)
        {
            View = view;
            //We initialize the default board in a separate thread in the background, before asking the user for the player infos.
            Thread boardInitializationThread = new Thread(() => InitializeBoard(boardCreator()));
            boardInitializationThread.Start();

            InitializePlayerList(playerListCreator());

            //Once the players are set up, we wait for the board to finish its initialization before joining the threads.
            boardInitializationThread.Join();
        }

        /// <summary>
        /// Replace all instances of a player to another. For example, in order to replace all instances of a Player to a JailedPlayer.
        /// </summary>
        /// <param name="oldPlayer">old IPlayer instance to replace</param>
        /// <param name="newPlayer">new IPlayer instance to put in place of the old one</param>
        public static void ReplaceIPlayerInstances(IPlayer oldPlayer, IPlayer newPlayer)
        {
            //Replace the player from the player list
            int playerIndex = Game.Instance.Players.IndexOf(oldPlayer);
            Game.Instance.Players[playerIndex] = newPlayer;

            //Replace the player instance from his owned properties
            foreach (Property ownedProperty in oldPlayer.OwnedProperties)
            {
                ownedProperty.Owner = newPlayer;
            }
            //TODO : Replace the instance in any other field it may be added on later.
        }

        /// <summary>
        /// Launch the game
        /// </summary>
        public void LaunchGame()
        {

            if (View == null || board == null || players == null)
            {
                throw new NullReferenceException("The view, board or players list is not initialized. Ensure you initialized the Game beforehand.");
            }


            while (players.Count > 1)//The game continues while there's more than one player.
            {
                currentTurn++;

                foreach (IPlayer currentPlayer in players)
                {
                    do
                    {
                        //TODO : Display board and basic information for each player when it's his turn.
                        View.DisplayMessage($"{currentPlayer}, it is your turn.");
                        View.Pause();
                        View.DisplayBoard(this);
                        View.DisplayMoney(currentPlayer);
                        View.DisplayProperties(currentPlayer);

                        currentPlayer.Replay = false;
                        currentPlayer.PlayTurn();
                        if (currentPlayer.HasLost)
                        {
                            View.DisplayMessage($"{currentPlayer} : You lost");
                            //Since we are in a foreach, we can't remove him from the list right now.
                            //We firstly remove its references from the game, so that other players won't have to pay rent to this losing player for example, even though he already lost.
                            ReplaceIPlayerInstances(currentPlayer, null);
                            break;
                        }
                        View.Pause();
                    } while (currentPlayer.Replay);
                }
                players.RemoveAll(player => player == null);//We remove all the players that lost and thus were replaced by a null ref.
            }

            //TODO : Il ne reste qu'un joueur : Afficher message de fin de jeu
            View.DisplayEndGame(players.Last());
        }
    }
}
