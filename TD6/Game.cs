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

            //Faire les tours des joueurs un à un jusqu'à la banqueroute, et vérifier après chaque tour si banqueroute il y a afin de retirer le joueur du jeu
            //TODO : Si un joueur tombe en banqueroute, remplacer toutes ses instances par null, puis l'effacer de la liste des joueurs.
            //Ou l'effacer de la liste des joueurs puis remplacer par null
        }
    }
}
