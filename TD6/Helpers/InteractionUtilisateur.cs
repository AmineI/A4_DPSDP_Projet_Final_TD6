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
        /// <param name="listeIntitulesChoix">Liste d'intitulés de choix possibles</param>
        /// <returns>entier entre 0 et le nombre de choix possibles -1, représentant l'index du choix dans la liste de strings.</returns>
        public static int DemanderChoixInt(string message, IList<string> listeIntitulesChoix)
        {
            string lecture;
            bool valid = false;
            int choix = 0;
            ListerObjets<string>(message, listeIntitulesChoix);
            Console.WriteLine("Entrer un choix >");

            do
            {
                lecture = Console.ReadLine();
                try
                {
                    choix = Convert.ToInt32(lecture);
                    valid = true;
                    if (choix <= 0 || choix > listeIntitulesChoix.Count)
                    {
                        valid = false;
                        Console.WriteLine("Choix invalide, faites un choix parmi ceux présentés.>");
                    }
                }
                catch
                {
                    Console.WriteLine("Entrée invalide - Rentrez un nombre");
                }

            } while (!valid);//On redemande tant que l'entrée est invalide

            return choix - 1;//-1 pour rapporter le choix à un index entre 0 et length (exclu)
        }

        /// <summary>
        /// Affiche un message à l'utilisateur, et lui demande une entrée.
        /// <example> Par exemple:
        /// <code>
        ///    string nomJoueur = DemanderString("Quel est le nom du joueur ?");
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="message">Message à afficher pour expliquer à l'utilisateur ce qu'il doit écrire</param>
        /// <returns>string rentré par l'utilisateur.</returns>
        public static string DemanderString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        /// <summary>
        /// Affiche un message à l'utilisateur, et lui propose des choix parmi lesquels il doit en choisir un. 
        /// <example> Par exemple:
        /// <code>
        /// string lettre = DemanderChoixObjet≪String≫("Choisis une lettre", new string[] {"A","B","C","D"});
        /// <para/>
        /// Console.Write("Tu as choisi la lettre" + lettre);
        /// </code>
        /// </example>
        /// </summary>
        /// <typeparam name="T">Type des objets choisis à retourner</typeparam>
        /// <param name="message">Message à afficher pour expliquer le contexte à l'utilisateur</param>
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
