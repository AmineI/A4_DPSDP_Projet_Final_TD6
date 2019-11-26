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
        /// We get the sums of the dice 
        /// </summary>
        int DiceValue { get; }

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
        void Pay(int amount, IPlayer destinationPlayer);

        /// <summary>
        /// Earn money from someone
        /// </summary>
        /// <param name="amount">amount of money to earn</param>
        void Earn(int amount);


        void PlayTurn();

    }
}
