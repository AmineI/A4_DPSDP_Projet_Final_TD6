using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TD6
{
    public class Game
    {
        private IBoard board = new Board();
        public IBoard Board { get => board; }
        private List<IPlayer> players;
        public List<IPlayer> Players { get => players; }
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

        public void InitializeBoard(Board board)
        {
            this.board = board;
        }
        public void InitializeDefaultBoard()
        {
            InitializeBoard(InternationalBoardBuilder.BuildDefaultBoard());
        }
        public void InitializePlayerList(List<IPlayer> players)
        {
            //Todo : (Ré)Initialiser chaque joueur : A l'aide d'une Factory de joueur ? Ils ont par défaut un certain montant d'argent notamment. 

            this.players = players;
        }

        //Initialize both the game board and the players 
        public void InitializeGame()
        {
            //We initialize the default board in a separate thread in the background, before asking the user for the player infos.
            Thread boardInitializationThread = new Thread(InitializeDefaultBoard);
            boardInitializationThread.Start();

            List<IPlayer> playerList = null;//TODO : appeler une fonction interface utilisateur qui demande les infos d'un joueur jusqu'à ce que l'utilisateur dise qu'il n'y a plus de joueurs

            InitializePlayerList(playerList);

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
                throw new NullReferenceException("The board or players list is not initialized. Ensure you called Game.InitializeGame beforehand.");
            }

            //Faire les tours des joueurs un à un jusqu'à la banqueroute, et vérifier après chaque tour si banqueroute il y a afin de retirer le joueur du jeu
            //TODO : Si un joueur tombe en banqueroute, remplacer toutes ses instances par null, puis l'effacer de la liste des joueurs.
            //Ou l'effacer de la liste des joueurs puis remplacer par null
        }
    }
}
