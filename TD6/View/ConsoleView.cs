using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD6
{
    public class ConsoleView : IView
    {
        public ConsoleView()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.SetWindowPosition(0, 0);//TODO : Does not work 
            Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 2);
            Console.Title = "Monopoly";
        }

        /// <summary>
        /// Ask the player if he wants to buy the property
        /// </summary>
        /// <param name="property"></param>
        /// <returns> A boolean representing the response of the player</returns>
        public bool GetPurchaseConfirmation(Property propertyToBuy, int PriceToBuyFor, IPlayer playerToBuyFrom)
        {
            return UserInteraction.GetConfirmation($"Do you want to buy {propertyToBuy} for {PriceToBuyFor}$ ?");
        }

        /// <summary>
        /// Ask the player if he wants to sell the property
        /// </summary>
        /// <param name="property"></param>
        /// <returns> A boolean representing the response of the player</returns>
        public bool GetSaleConfirmation(Property propertyToSell, int priceToSellFor, IPlayer playerToSellTo)
        {
            return UserInteraction.GetConfirmation($"Do you want to sell {propertyToSell} for {priceToSellFor}$ to {playerToSellTo} ?");
        }

        /// <summary>
        /// Ask the player if he wants to build a house on the land
        /// </summary>
        /// <param name="land"></param>
        /// <returns> A boolean representing the response of the player</returns>
        public bool GetBuildHouseHereConfirmation(Land land)
        {
            return UserInteraction.GetConfirmation($"Do you want to build a house on {land} for {land.HousePrice}$ ?");
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
            IList<Land> buildableOwnedLands = player.BuildableOwnedLands;
            if (buildableOwnedLands.Count == 0)
            {
                DisplayMessage("There is no land you can build a house on.");
                return null;
            }
            else
            {
                return UserInteraction.GetObjectChoice<Land>("Where do you want to build your house ?", buildableOwnedLands);
            }
        }

        public void SellPropertyInterface(IGame gameInstance, IPlayer player)
        {
            if (player.OwnedProperties.Count == 0)
            {
                DisplayMessage("You own no properties that you could sell");
                return;
            }

            Property propertyToSell = GetObjectChoice<Property>("Choose a property to sell", player.OwnedProperties);
            IPlayer playerToSellTo = GetObjectChoice<IPlayer>("Choose a player to sell to", gameInstance.Players);
            int priceToSellFor = GetEnteredInt();
            if (propertyToSell != null && GetSaleConfirmation(propertyToSell, priceToSellFor, playerToSellTo))
            {
                if (playerToSellTo.Money >= priceToSellFor && playerToSellTo.View.GetPurchaseConfirmation(propertyToSell, priceToSellFor, (IPlayer)player))
                {
                    playerToSellTo.Pay(priceToSellFor, (IPlayer)player);
                    propertyToSell.Owner = playerToSellTo;
                }
            }

        }

        public void BuildHouseInterface(IPlayer player)
        {
            Land land = ChooseLandToBuildOn(player);
            if (land != null && GetBuildHouseHereConfirmation(land))
            {
                land.BuildHouse();
            }
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
            List<Property> properties = player.OwnedProperties;
            if (properties != null)
            {
                UserInteraction.DisplayObjectList<Property>("Here is the list of your properties :", player.OwnedProperties);
            }
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
            Console.WriteLine("Well done, the game is over.\n" +
                "You finished this game with " + player.Money + " $.\n" +
                "You had " + player.OwnedProperties.Count + " properties.");
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

        public void DisplayBoard(IGame game, int highlightedSpace = -1)
        {
            ConsoleColor defaultBackgroundColor = Console.BackgroundColor;//Saves the default background color

            Console.WriteLine();
            //Display the board spaces and numbers.
            for (int spaceNumber = 0; spaceNumber < game.Board.Count; spaceNumber++)
            {
                ConsoleColor consoleColor = ColorConverter(game.Board[spaceNumber].Color);
                if (spaceNumber == highlightedSpace)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                Console.ForegroundColor = consoleColor;
                Console.Write(spaceNumber);
                Console.ForegroundColor = ConsoleColor.White;
                if (spaceNumber < 10)
                {//If the number we display has less than 2 characters, we add a space so that each displayed "space" has a 3 characters length.
                    Console.Write(" ");
                }
                Console.BackgroundColor = defaultBackgroundColor;
                if (spaceNumber < game.Board.Count - 1)
                {
                    Console.Write(" |");
                }
            }
            Console.WriteLine();

            List<IPlayer> playersToDisplay = new List<IPlayer>(game.Players);
            int displayedCount;
            //While there are still players, we display an additional line with these players.
            while (playersToDisplay.Count > 0)
            {
                for (int spaceNumber = 0; spaceNumber < game.Board.Count; spaceNumber++)
                {
                    displayedCount = 0;
                    List<IPlayer> playersOnThisSpace = playersToDisplay.FindAll(player => player.CurrentPosition == spaceNumber);
                    foreach (IPlayer player in playersOnThisSpace)
                    {
                        displayedCount++;
                        Console.Write(player.DisplayCharacter);
                        playersToDisplay.Remove(player);
                        if (displayedCount >= 3)
                        {
                            break;
                        }
                    }
                    while (displayedCount < 3)
                    {
                        Console.Write(" ");
                        displayedCount++;
                    }
                    if (spaceNumber < game.Board.Count - 1)
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
            }
        }

        private ConsoleColor ColorConverter(Color colorToConvert)
        {
            ConsoleColor consoleColor;
            switch (colorToConvert)
            {
                case Color.Gray:
                    consoleColor = ConsoleColor.Gray;
                    break;
                case Color.Blue:
                    consoleColor = ConsoleColor.Blue;
                    break;
                case Color.Brown:
                    consoleColor = ConsoleColor.DarkRed;
                    break;
                case Color.Cyan:
                    consoleColor = ConsoleColor.Cyan;
                    break;
                case Color.Green:
                    consoleColor = ConsoleColor.Green;
                    break;
                case Color.Orange:
                    consoleColor = ConsoleColor.DarkYellow;
                    break;
                case Color.Purple:
                    consoleColor = ConsoleColor.Magenta;
                    break;
                case Color.Red:
                    consoleColor = ConsoleColor.Red;
                    break;
                case Color.Yellow:
                    consoleColor = ConsoleColor.Yellow;
                    break;
                default:
                    consoleColor = ConsoleColor.White;
                    break;
            }
            return consoleColor;
        }

        public T GetObjectChoice<T>(string message, IList<T> choicesList, IList<string> choicesTitlesList = null)
        {
            return UserInteraction.GetObjectChoice<T>(message, choicesList, choicesTitlesList);
        }

        public int GetEnteredInt(string message = null)
        {
            return Convert.ToInt32(UserInteraction.GetEnteredDouble(message));
        }
    }
}
