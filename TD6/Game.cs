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
        private IList<IPlayer> players;
        public IList<IPlayer> Players { get => players; }
        private int currentTurn;
        public int CurrentTurn { get => currentTurn; }


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
            this.players = players;
        }

        /// <summary>
        /// Initialize both the game board and the players thanks to the delegates method given.
        /// Is optimized to use two threads : one  taking care of the board, and one taking care of the player list.
        /// </summary>
        public void InitializeGame(IBoardCreator boardCreator, IPlayerListCreator playerListCreator)
        {

            //We initialize the default board in a separate thread in the background, before asking the user for the player infos.
            Thread boardInitializationThread = new Thread(() => InitializeBoard(boardCreator()));
            boardInitializationThread.Start();

            InitializePlayerList(playerListCreator());

            //Once the players are set up, we wait for the board to finish its initialization before joining the threads.
            boardInitializationThread.Join();
        }

        /// <summary>
        /// Launch the game
        /// </summary>
        public void LaunchGame()
        {

            if (board == null || players == null)
            {
                throw new NullReferenceException("The board or players list is not initialized. Ensure you initialized the Game beforehand.");
            }

            //TODO : Display board and basic information for each player when it's his turn.

            while (players.Count > 1)//The game continues while there's more than one player.
            {
                List<IPlayer> losingPlayers = new List<IPlayer>();
                foreach (IPlayer currentPlayer in players)
                {
                    currentPlayer.PlayTurn();
                    if (currentPlayer.HasLost)
                    {
                        //TODO : Afficher message comme quoi le joueur a perdu
                        //Adds the player to the list of losing players, to remove them later : 
                        //Since we are in a foreach, we can't eliminate him right now. (or can we ? For example by setting it to null and checking against null references in the foreach)
                        //If we don't eliminate him now, or at least remove his ownership of his properties, then other players would still have to pay rent to this losing player, even though he already lost.
                        losingPlayers.Add(currentPlayer);
                    }
                }

                losingPlayers.ForEach((losingPlayer) => EliminatePlayer(losingPlayer));
            }

            //TODO : Il ne reste qu'un joueur : Afficher message de fin de jeu
        }

        private void EliminatePlayer(IPlayer losingPlayer)
        {
            //TODO : Replace all instances of the player to null (using the function in PR #22 
            //TODO : Then remove the player from the player list (the null reference)
        }
    }
}
