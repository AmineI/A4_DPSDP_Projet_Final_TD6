using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public class Plateau
    {
        private List<Case> boardSpaces;
        public Case this[int key]
        {
            get => boardSpaces[key];
        }

        //TODO : Si on ajoute la cagnotte au centre, la stocker sur le plateau

        public Plateau()
        {
            boardSpaces = new List<Case>();
        }

        //TODO : créer et ajouter toutes les cases du plateau à la liste de cases.
        //TODO : Builder pattern maybe ?

        //TODO implémenter un indexer pour acceder aux cases du plateau
        //TODO ? Implémenter un enumerator/iterator pour iterer sur le plateau sans avoir accès à la liste de cases ?

    }
}
