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



        public int FindSpaceIndex(IVisitableSpace searchedSpace)
        {
            return boardSpaces.FindIndex(space => searchedSpace==space);
        }
        
        //TODO ? Implémenter un enumerator/iterator pour iterer sur le plateau sans avoir accès à la liste de cases ?

    }
}
