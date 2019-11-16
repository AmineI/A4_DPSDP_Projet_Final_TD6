using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TD6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans le Monopoly");
            do {
                Jeu.LancerPartie();
                //Lorsque la partie se termine, l'utilisateur peut choisir s'il en lance une nouvelle ou pas
            } while (InteractionUtilisateur.ObtenirConfirmation("Voulez vous recommencer une nouvelle partie ?"));
        }
    }
}
