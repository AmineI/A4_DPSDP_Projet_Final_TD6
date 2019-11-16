using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public class Jeu
    {
        /// <summary>
        /// On stocke l'unique instance du Jeu dans une variable statique.
        /// </summary>
        static private Jeu jeu = new Jeu();
        /// <summary>
        /// On permet à l'utilisateur l'accès à notre plateau unique
        /// </summary>
        public static Jeu GetJeu
        {
            get => jeu;
        }
        /// <summary>
        /// Le constructeur de Jeu est privé pour que personne ne puisse créer de nouveau Jeu : cela garantit l'unicité de notre jeu.
        /// </summary>
        private Jeu()
        {
        }
        //TODO : stocker une liste de joueurs

        /// <summary>
        ///Fonction lancant une partie de Monopoly. 
        /// </summary>
        public static void LancerPartie()
        {
            //Todo : (Ré)Initialiser le plateau
            //Todo : Demander nombre de joueurs
            //Todo : (Ré)Initialiser chaque joueur : A l'aide d'une Factory de joueur ? Ils ont par défaut un certain montant d'argent notamment. 
            //TODO : Peut etre qu'on peut initialiser le plateau dans un thread séparé pendant qu'on demande les infos sur les joueurs !?
        }
    }
}