using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TD6
{
    public class Game
    {
        private Board board;
        private List<Player> players;
        private int currentTurn;
        

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

        /// <summary>
        /// Launch the game
        /// </summary>
        public void LaunchGame()
        {            
            //Todo : (Ré)Initialiser le plateau
            //Todo : Demander nombre de joueurs
            //Todo : (Ré)Initialiser chaque joueur : A l'aide d'une Factory de joueur ? Ils ont par défaut un certain montant d'argent notamment. 
            //TODO : Peut etre qu'on peut initialiser le plateau dans un thread séparé pendant qu'on demande les infos sur les joueurs !?
        }
    }
}
