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
        /// On stocke l'unique instance du plateau dans une variable statique.
        /// </summary>
        static private Plateau plateau;
        /// <summary>
        /// On permet à l'utilisateur l'accès à notre plateau unique
        /// </summary>
        static public Plateau GetPlateau
        {
            get => plateau;
        }
        /// <summary>
        /// Le constructeur de Plateau est privé pour que personne ne puisse créer de nouveau plateau : cela garantit l'unicité de notre plateau.
        /// </summary>
        private Plateau()
        {
            //Initialiser la liste de cases vides
        }

        /// <summary>
        /// Initialise ou réinitialise le plateau et ses cases
        /// </summary>
        public static void Initialiser()
        {
            plateau = new Plateau();
            //TODO : créer et ajouter toutes les cases du plateau à la liste de cases.
        }
        //TODO implémenter une List<Case> (private ?)
        //TODO implémenter un indexer pour acceder aux cases du plateau
        //TODO ? Implémenter un enumerator/iterator pour iterer sur le plateau sans avoir accès à la liste de cases ?

    }
}
