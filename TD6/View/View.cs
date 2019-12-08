using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6.View
{
    public class View : IView
    {
        /// <summary>
        /// Ask the player if he wants to buy the property
        /// </summary>
        /// <param name="property"></param>
        /// <returns> A boolean representing the response of the player</returns>
        public bool ConfirmationPurchase(Property property)
        {
            bool confirmation = UserInteraction.GetConfirmation("Do you want to buy " + property.Name + " ?");
            return confirmation;
        }

        /// <summary>
        /// Ask the player if he wants to sale the property
        /// </summary>
        /// <param name="property"></param>
        /// <returns> A boolean representing the response of the player</returns>
        public bool ConfirmationSale(Property property)
        {
            bool confirmation = UserInteraction.GetConfirmation("Do you want to sale " + property.Name + " ?");
            return confirmation;
        }

        /// <summary>
        /// Display the message in the setting
        /// </summary>
        /// <param name="message"></param>
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
