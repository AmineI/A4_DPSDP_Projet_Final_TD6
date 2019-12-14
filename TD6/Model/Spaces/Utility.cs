using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{

    public class Utility : Property, IVisitableSpace
    {


        /// <param name="rentPriceMultiplicator">rent price multiplicator list according to whether or not all utilities belong to the same player. The rent price will be (the multiplicator * the dice value)</param>
        public Utility(string id, string name, int buyPrice, int[] rentPriceMultiplicator, IBoard board = null) : base(id, name, buyPrice, rentPriceMultiplicator, board)
        {
        }
        private int lastDicesValue = 0;
        public override int RentPrice
        {
            get => GetRentPrice(lastDicesValue);
        }

        public override bool CanBeSold => true;

        public bool IsMonopolized { get => IsUtilityMonopolized(board); }

        /// <summary>
        /// This function gives the rent of the Utility based on the number of utilities owned by the land owner.
        /// </summary>
        /// <param name="dicesValue">Value of the dice roll used to get on this space.</param>
        /// <returns> An integer representing the price of rent</returns>
        public int GetRentPrice(int dicesValue)
        {
            //We get the base rent price according to the number of houses
            int rentPrice;
            if (!IsMonopolized)
            {
                rentPrice = rentPrices[0] * dicesValue;
            }
            else
            {
                rentPrice = rentPrices[1] * dicesValue;
            }

            return rentPrice;
        }

        /// <summary>
        /// Check if the utilities are monopolized, ie all utilities are owned by the same player
        /// </summary>
        /// <param name="board">Board we are checking against. Default to the game board</param>
        /// <returns>true if the utilities are monopolized (owned by the same player), false otherwise.</returns>
        public static bool IsUtilityMonopolized(IBoard board)
        {
            //We gather the list of utilities 
            List<Utility> utilities = board.FindAllSpaces<Utility>((utility) => true);

            //We get the owner of the first utility
            IPlayer firstUtilityOwner = utilities.FirstOrDefault<Utility>().Owner;

            //And then check if he owns all the lands of that color. If he does, the color is in a monopoly.
            return utilities.All(utility => utility.Owner == firstUtilityOwner);
        }


        public override void AcceptStopping(ISpaceVisitor visitor)
        {
            lastDicesValue = visitor.DicesValue;//We store the dice value when a visitor stops here, in order to charge him rent correctly afterwards. 
            base.AcceptStopping(visitor);
        }

        public override string ToString()
        {
            if (Owner == null)
            {
                return $"{Name}, nobody owns this utility, the buy price is {BuyPrice}$";
            }
            else
            {
                return $"{Name}, his owner is {Owner}, the rent price is {RentPrice}$";
            }
        }
    }
}
