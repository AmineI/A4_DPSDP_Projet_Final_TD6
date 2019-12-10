using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public interface IPlayer
    {
        /// <summary>
        /// Unique Id of the player 
        /// </summary>
        int Id { get; }

        /// <summary>
        /// The character associated with the player in order to spot him on the board
        /// </summary>
        char DisplayCharacter { get; }

        /// <summary>
        /// Display name of the player
        /// </summary>
        string PlayerName { get; }

        /// <summary>
        /// Position of the player on the board
        /// </summary>
        int CurrentPosition { get; }

        /// <summary>
        /// Amount of money of the player
        /// </summary>
        int Money { get; }

        /// <summary>
        /// List of properties owned by the player.
        /// </summary>
        List<Property> OwnedProperties { get; }
        /// <summary>
        /// List of lands owned by the player where he can build a house.
        /// </summary>
        List<Land> BuildableOwnedLands { get; }
        /// <summary>
        /// We get the sums of the dice 
        /// </summary>
        int DicesValue { get; }

        /// <summary>
        /// We check if dices are equal and get the bool value
        /// </summary>
        bool IsDiceDouble { get; }

        /// <summary>
        /// Roll our two dices.
        /// </summary>
        void RollDices();

        /// <summary>
        /// Pay money to someone.
        /// </summary>
        /// <param name="amount">Amount of money to pay</param>
        /// <param name="destinationPlayer">Player to pay. If null, it pays the bank</param>
        void Pay(int amount, IPlayer destinationPlayer = null);

        /// <summary>
        /// Earn money from someone
        /// </summary>
        /// <param name="amount">amount of money to earn</param>
        void Earn(int amount);

        /// <summary>
        /// Put the player behind the bars. He will be teleported to the Jail space and he will be jailed 
        /// </summary>
        void GoToJail();

        /// <summary>
        /// Removes a player from the jail, allowing him to move freely
        /// </summary>
        void GetOutOfJail();

        /// <summary>
        /// Teleport the player on a space, with or without passing through the go space and earning its money
        /// </summary>
        /// <param name="arrival">Destination space</param>
        /// <param name="passThroughGoSpace">True if the user has to pass through the go space while teleporting.</param>
        void Teleport(IVisitableSpace arrival, bool passThroughGoSpace = false);

        /// <summary>
        /// Moves the player, and walk on each space on the way to the destination, then stop on the destination space. Fires any action due to walking or stopping on a space.
        /// </summary>
        /// <param name="distanceToMove">distance to move, forwards or backwards depending on if it is positive or negative </param>
        void Move(int distanceToMove);
        void PlayTurn();
    }
}
