using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public class Plateau
    {
        /// <summary>
        /// We store the only instance of a Board in a static variable.
        /// </summary>
        static private Plateau board;

        private List<Case> boardSpaces;
        public Case this[int key]
        {
            get => boardSpaces[key];
        }

        /// <summary>
        /// We provide access to our unique Board
        /// </summary>
        static public Plateau Board
        {
            get => board;
        }

        /// <summary>
        /// The Board constructor is private so that we can't create a new Board : It ensures the uniqueness of our Board.
        /// </summary>
        private Plateau()
        {
            boardSpaces = new List<Case>();
        }

        /// <summary>
        /// Initialize or reinitialize the board and its spaces
        /// </summary>
        public static void Initialize()
        {
            board = new Plateau();
            //TODO : créer et ajouter toutes les cases du plateau à la liste de cases.
            //TODO : Builder pattern maybe ?
        }
        //TODO implémenter un indexer pour acceder aux cases du plateau
        //TODO ? Implémenter un enumerator/iterator pour iterer sur le plateau sans avoir accès à la liste de cases ?

    }
}
