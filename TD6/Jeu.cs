using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TD6
{
    public class Jeu
    {
        private Plateau board;
        private List<Joueur> players;
        private int currentTurn;
        

        /// <summary>
        /// We store the unique instance of the Game in a static variable
        /// </summary>
        static private Jeu game = new Jeu();
        /// <summary>
        /// We allow the user to access our unique Game instance
        /// </summary>
        public static Jeu Instance
        {
            get => game;
        }
        
        
        /// <summary>
        /// The constructor is private to ensure the uniqueness of the Game.
        /// </summary>
        private Jeu()
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
