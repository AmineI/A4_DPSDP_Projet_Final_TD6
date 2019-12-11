using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public class ConsoleView : IView
    {
        protected IBoard board;

        /// <summary>
        /// Ask the player if he wants to buy the property
        /// </summary>
        /// <param name="property"></param>
        /// <returns> A boolean representing the response of the player</returns>
        public bool GetPurchaseConfirmation(Property property)
        {
            return UserInteraction.GetConfirmation("Do you want to buy " + property.Name + " for " + property.BuyPrice + "$ ?");
        }

        /// <summary>
        /// Ask the player if he wants to sell the property
        /// </summary>
        /// <param name="property"></param>
        /// <returns> A boolean representing the response of the player</returns>
        public bool GetSaleConfirmation(Property property)
        {
            return UserInteraction.GetConfirmation("Do you want to sell " + property.Name + " ?");
        }

        /// <summary>
        /// Ask the player if he wants to build a house on the land
        /// </summary>
        /// <param name="land"></param>
        /// <returns> A boolean representing the response of the player</returns>
        public bool GetBuildHouseHereConfirmation(Land land)
        {
            return UserInteraction.GetConfirmation("Do you want to build a house on " + land.Name + " for " + land.HousePrice + "$ ?");
        }

        /// <summary>
        /// Ask the player if he wants to build a house somewhere
        /// </summary>
        /// <returns> A boolean representing the response of the player</returns>
        public bool GetBuildHouseConfirmation()
        {
            return UserInteraction.GetConfirmation("Do you want to build a house ?");
        }

        /// <summary>
        /// Ask the player where he wants to build his house
        /// </summary>
        /// <param name="player"></param>
        /// <returns> The land where the player wants to build his house </returns>
        public Land ChooseLandToBuildOn(IPlayer player)
        {

            return UserInteraction.GetObjectChoice<Land>("Where do you want to build your house ?", player.BuildableOwnedLands);
        }

        /// <summary>
        /// Displays a message
        /// </summary>
        /// <param name="message">message we want to display</param>
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Display the properties of the player
        /// </summary>
        /// <param name="player"></param>
        public void DisplayProperties(IPlayer player)
        {
            UserInteraction.DisplayObjectList<Property>("Here is the list of your properties :", player.OwnedProperties);
        }

        /// <summary>
        /// Display a message with the money of the player
        /// </summary>
        /// <param name="player">player whose money we want to display</param>
        public void DisplayMoney(IPlayer player)
        {
            Console.WriteLine("You have " + player.Money + "$.");
        }

        public void DisplayEndGame(IPlayer player)
        {
            Console.WriteLine("Well done, the game is over.");
            Console.WriteLine("You finished this game with " + player.Money + " $.");
            Console.WriteLine("You had " + player.OwnedProperties.Count + " properties.");
        }

        /// <summary>
        /// Clear the console
        /// </summary>
        public void ClearView()
        {
            Console.Clear();
        }

        public bool GetConfirmation(string message = "Do you want to continue ?")
        {
            return UserInteraction.GetConfirmation(message);
        }

        public string GetEnteredString(string message)
        {
            return UserInteraction.GetEnteredString(message);
        }

        public void Pause()
        {
            DisplayMessage("Press any key to continue");
            Console.ReadKey();
        }

        public void DisplayBoard(IBoard board)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
