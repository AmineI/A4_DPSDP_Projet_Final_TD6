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
        public static bool GetConfirmation(string message = "Do you want to continue ?")
        {
            bool confirmation = GetObjectChoice<bool>(message, new bool[] { true, false }, new string[] { "Yes", "No" });
            return confirmation;
        }

        /// <summary>
        /// Print a list in the console
        /// </summary>
        /// <param name="message">Message to display to the user before the list </param>
        /// <param name="objectList">List of objects to print</param>
        public static void DisplayObjectList<T>(string message, IList<T> objectList)
        {
            Console.WriteLine(message);
            for (int index = 0; index < objectList.Count; index++)
            {
                Console.WriteLine($"{index + 1} - {objectList[index]}");
            }
        }

        /// <summary>
        /// Print a message to the user and offer him choices. The user must choose one. 
        /// </summary>
        /// <param name="message">Message to print to explain the context to the user</param>
        /// <param name="choicesTitlesList">List of choice titles</param>
        /// <returns>An integer between 0 and the number of choice -1. It's the index of the user's choice in the list.</returns>
        public static int GetChoosedInt(string message, IList<string> choicesTitlesList)
        {
            string response;
            bool valid = false;
            int choice = 0;
            DisplayObjectList<string>(message, choicesTitlesList);
            Console.WriteLine("Make a choice >");

            do
            {
                response = Console.ReadLine();
                try
                {
                    choice = Convert.ToInt32(response);
                    valid = true;
                    if (choice <= 0 || choice > choicesTitlesList.Count)
                    {
                        valid = false;
                        Console.WriteLine("Invalid choice, choose an existing option>");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input, enter an integer please.");
                }

            } while (!valid);//We ask it as long as the input is invalid.

            return choice - 1; //-1 to put the choice in a range of index between 0 and length-1
        }

        /// <summary>
        /// Dispaly a message to the user and ask him for an input.
        /// <example> For example:
        /// <code>
        ///    string playerName = GetEnteredString("What's the player's name ?");
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="message">Message to display to the user to tell him what to enter</param>
        /// <returns>string entered by the user.</returns>
        public static string GetEnteredString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        /// <summary>
        /// Print a message to the user and offer him choices. The user must choose one.  
        /// <example> For example:
        /// <code>
        /// string character = GetObjectChoice≪String≫("Choose a character", new string[] {"A","B","C","D"});
        /// <para/>
        /// Console.Write("You chose the letter : " + character);
        /// </code>
        /// </example>
        /// </summary>
        /// <typeparam name="T">Type of objects chosen to return</typeparam>
        /// <param name="message">Message to print to explain the context to the user.</param>
        /// <param name="choicesList">Objects from which the user can choose.</param>
        /// <param name="choicesTitlesList">Optional : List of choice titles. If it is not provided, it uses the ToString of the objects as titles.</param>
        /// <returns>The chosen object, or null if there is no object in the provided list</returns>
        public static T GetObjectChoice<T>(string message, IList<T> choicesList, IList<string> choicesTitlesList = null)
        {
            T choosedObject = default(T);
            if (choicesList.Count == 0)
            {
                choicesList = new[] { default(T) };
                choicesTitlesList = new[] { "No choice available. Return." };
            }
            if (choicesTitlesList == null)
            {
                choicesTitlesList = new string[choicesList.Count];//New list with the same length as the number of choices
                for (int i = 0; i < choicesList.Count; i++)
                {
                    choicesTitlesList[i] = choicesList[i].ToString();
                }
            }
            int choice = GetChoosedInt(message, choicesTitlesList);
            choosedObject = choicesList[choice]; //The object chosen is the object corresponding to the number chosen in the list by the user. 
            return choosedObject;
        }

        /// <summary>
        /// Asks the user one by one several settings.
        /// <example> For example:
        /// <code>
        /// Dictionary≪string, string≫ setting = GetEnteredParameters(new [] {"player's first name", "player's last name"}); 
        /// <para/>
        /// Console.Write("Hello " + setting["player's first name"] + setting["player's last name"])
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="parametersToGet"> Array of the names of the parameters to ask. Will be used as keys to the dico and displayed to the user when requesting</param>
        /// <returns>Dictionary of keys settings and values values entered by the user</returns>
        public static Dictionary<string, string> GetEnteredParameters(IList<string> parametersToGet)
        {
            Dictionary<string, string> choice = new Dictionary<string, string>();
            foreach (string parameter in parametersToGet)
            {
                choice.Add(parameter, GetEnteredString($"Enter {parameter}"));
            }
            return choice;
        }

        /// <summary>
        /// Asks the user for a double
        /// </summary>
        /// <param name="message">Message to print to explain the context to the user.</param>
        /// <returns>double corresponding to the user input</returns>
        public static double GetEnteredDouble(string message = "Enter a number")
        {
            Console.WriteLine($"{message}");
            string response;
            double number = 0;
            bool valid;
            do
            {
                response = Console.ReadLine();
                try
                {
                    number = Convert.ToDouble(response);
                    valid = true;
                }
                catch
                {
                    valid = false;
                    Console.WriteLine("Invalid number. Please retry");
                }
            } while (!valid);
            return number;
        }
    }
}
