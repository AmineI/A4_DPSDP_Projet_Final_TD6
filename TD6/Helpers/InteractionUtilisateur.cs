using System;
using System.Collections.Generic;

namespace TD6
{
    public static class UserInteraction
    {
        /// <summary>
        /// Asks the user for confirmation
        /// </summary>
        /// <param name="message">Message to display to the user</param>
        /// <returns>true or false depending on the user's confirmation</returns>
        public static bool GetConfirmation(string message = "Do you want to continu ?")
        {
            bool confirmation = DemanderChoixObjet<bool>(message, new bool[] { true, false }, new string[] { "Yes", "No" });
            return confirmation;
        }

        /// <summary>
        /// Print a list in the console
        /// </summary>
        /// <param name="message">Message to display to the user before the list </param>
        /// <param name="choiceList">List to print</param>
        public static void ListerObjets<T>(string message, IList<T> choiceList)
        {
            Console.WriteLine(message);
            for (int index = 0; index < choiceList.Count; index++)
            {
                Console.WriteLine($"{index + 1} - {choiceList[index]}");
            }
        }

        /// <summary>
        /// Print a message to the user and offer him choices. The user must choose one. 
        /// </summary>
        /// <param name="message">Message to print to explain the context to the user</param>
        /// <param name="listeIntitulesChoix">List of choice titles</param>
        /// <returns>An integer between 0 and the number of choice -1. It's the index of the user's choice in the list.</returns>
        public static int DemanderChoixInt(string message, IList<string> listeIntitulesChoix)
        {
            string response;
            bool valid = false;
            int choice = 0;
            ListerObjets<string>(message, listeIntitulesChoix);
            Console.WriteLine("Make a choice >");

            do
            {
                response = Console.ReadLine();
                try
                {
                    choice = Convert.ToInt32(response);
                    valid = true;
                    if (choice <= 0 || choice > listeIntitulesChoix.Count)
                    {
                        valid = false;
                        Console.WriteLine("Invalid choice, choose an existing option.>");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input, enter an integer please.");
                }

            } while (!valid);//We ask it while the input is invalid.

            return choice - 1; //-1 to put the choice in an index between 0 and length-1
        }

        /// <summary>
        /// Dispaly a message to the user and ask him for an input.
        /// <example> For exemple:
        /// <code>
        ///    string nomJoueur = DemanderString("What's the player's name ?");
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="message">Message to display to the user to tell him what to do</param>
        /// <returns>string entered by the user.</returns>
        public static string DemanderString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        /// <summary>
        /// Print a message to the user and offer him choices. The user must choose one.  
        /// <example> For exemple:
        /// <code>
        /// string character = DemanderChoixObjet≪String≫("Choose a character", new string[] {"A","B","C","D"});
        /// <para/>
        /// Console.Write("You chose the letter : " + character);
        /// </code>
        /// </example>
        /// </summary>
        /// <typeparam name="T">Type of objects chosen to return</typeparam>
        /// <param name="message">Message to print to explain the context to the user</param>
        /// <param name="listeChoix">Objets parmi lesquels l'utilisateur peut choisir </param>
        /// <param name="listeIntitulesChoix">Optionnel : Une liste d'intitulé de choix. Si elle n'est pas renseignée, utilise les représentations textuelles des objets comme intitulés. (ie leur ToString)</param>
        /// <returns>L'objet choisi</returns>
        public static T DemanderChoixObjet<T>(string message, IList<T> listeChoix, string[] listeIntitulesChoix = null)
        {
            T objetChoisi;
            if (listeIntitulesChoix == null)
            {
                listeIntitulesChoix = new string[listeChoix.Count];//Nouvelle liste de longueur identique au nombre de choix
                for (int i = 0; i < listeChoix.Count; i++)
                {
                    listeIntitulesChoix[i] = listeChoix[i].ToString();
                }
            }
            int choix = DemanderChoixInt(message, listeIntitulesChoix);
            objetChoisi = listeChoix[choix];//L'objet choisi est celui de la liste correspondant au numéro choisi par l'utilisateur. 
            return objetChoisi;
        }

        /// <summary>
        /// Demande un par un plusieurs paramètres à l'utilisateur
        /// <example> Par exemple:
        /// <code>
        /// Dictionary≪string, string≫ parametres = DemanderParametres(new [] {"prenom du joueur", "nom du joueur"}); 
        /// <para/>
        /// Console.Write("Bonjour " + parametres["prenom du joueur"] + parametres["nom du joueur"])
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="parametresADemander">array des noms des parametres à demander. Seront utilisés comme clés du dico et affichés à l'utilisateur lors de la demande</param>
        /// <returns>Dico de clés paramètres et valeurs les valeurs entrées par l'utilisateur</returns>
        public static Dictionary<string, string> DemanderParametres(IList<string> parametresADemander)
        {
            Dictionary<string, string> choix = new Dictionary<string, string>();
            foreach (string parametre in parametresADemander)
            {
                choix.Add(parametre, DemanderString($"Rentrer {parametre}"));
            }
            return choix;
        }

        /// <summary>
        /// Demande un double à l'utilisateur
        /// </summary>
        /// <param name="message">Message de contexte à afficher</param>
        /// <returns>double correspondant à l'entrée utilisateur</returns>
        public static double DemanderDouble(string message = "Entrez un nombre")
        {
            Console.WriteLine($"{message}");
            string lecture;
            double nombre = 0;
            bool valid;
            do
            {
                lecture = Console.ReadLine();
                try
                {
                    nombre = Convert.ToDouble(lecture);
                    valid = true;
                }
                catch
                {
                    valid = false;
                    Console.WriteLine("Nombre invalide. Réessayer");
                }
            } while (!valid);
            return nombre;
        }
    }
}
