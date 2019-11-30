using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public class Board
    {
        private List<IVisitableSpace> boardSpaces;
        public int Count { get => boardSpaces.Count; }
        public IVisitableSpace this[int key]
        {
            get => boardSpaces[key];
        }


        //TODO : Si on ajoute la cagnotte au centre, la stocker sur le plateau

        public Board(List<IVisitableSpace> spacesList)
        {
            boardSpaces = spacesList;
        }

        //TODO : créer et ajouter toutes les cases du plateau à la liste de cases. Builder pattern maybe ?



        /// <summary>
        /// Find a specific space's index in the board.
        /// </summary>
        /// <param name="searchedSpace">Space we need the index for</param>
        /// <returns>Index in the board where the searchedSpace instance is located.</returns>
        public int IndexOfSpace(IVisitableSpace searchedSpace)
        {
            return boardSpaces.IndexOf(searchedSpace);
        }

        /// <summary>
        /// Obtain a list of all spaces of type S matching the conditions given in the match predicate
        /// <para/>
        /// <example> For example
        /// <code>
        /// FindAllSpaces≪Railroad≫(railroad=>railroad.Owner==player1);
        /// </code>
        /// </example>
        /// </summary>
        /// <typeparam name="S">Type of space searched : Land, Railroad, etc</typeparam>
        /// <param name="match">predicate that has to be verified for a space to be included in the result</param>
        /// <returns>List of Spaces of type S matching the conditions given in the match predicate </returns>
        public List<S> FindAllSpaces<S>(Predicate<S> match) where S : Space
        {
            return boardSpaces.OfType<S>()//Takes only the items of requested types from the space list
                              .ToList()//Cast back the enumerable obtained to a list
                              .FindAll(match);//And find the elements that match our predicate.
        }

    }
}
