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
        public Board Board { get => board; }
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
            //Todo : (Ré)Initialiser le plateau
            //Todo : Demander nombre de joueurs
            //Todo : (Ré)Initialiser chaque joueur : A l'aide d'une Factory de joueur ? Ils ont par défaut un certain montant d'argent notamment. 
            //TODO : Peut etre qu'on peut initialiser le plateau dans un thread séparé pendant qu'on demande les infos sur les joueurs !?
        }
    }
}
