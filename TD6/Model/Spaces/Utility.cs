using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{

    public class Utility : Property, IVisitableSpace
    {


        /// <param name="rentPrice">rent price list according to the number of houses built on the land. Up to 6 houses.</param>
        public Utility(string id, string name, int buyPrice, IBoard board = null) : base(id, name, buyPrice, new int[] { }, board)
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
        /// This function gives the rent of the land based on the number of houses and land owned by the land owner.
        /// </summary>
        /// <param name="dicesValue">Value of the dice roll used to get on this space.</param>
        /// <returns> An integer representing the price of rent</returns>
        public int GetRentPrice(int dicesValue)
        {
            //We get the base rent price according to the number of houses
            int rentPrice;
            if (IsMonopolized)
            {
                rentPrice = 10 * dicesValue;
            }
            else
            {
                rentPrice = 4 * dicesValue;
            }

            return rentPrice;
        }

        /// <summary>
        /// Check if a given color group is monopolized, ie all lands of that color group are owned by the same player
        /// </summary>
        /// <param name="color">Color of the group we want to check</param>
        /// <param name="board">Board we are checking against. Default to the game board</param>
        /// <returns>true if the color group is monopolized (owned by the same player), false otherwise.</returns>
        public static bool IsUtilityMonopolized(IBoard board)
        {
            //We gather the list of utilities 
            List<Utility> utilities = board.FindAllSpaces<Utility>((utility) => true);

            //We get the owner of the first utility
            IPlayer firstUtilityOwner = utilities.First<Utility>().Owner;

            //And then check if he owns all the lands of that color. If he does, the color is in a monopoly.
            return utilities.All(utility => utility.Owner == firstUtilityOwner);
        }


        /// <summary>
        /// Accept a visitor that is stopping on the space after walking on it, and act according to the type of space visited  (by calling the visitor's StopOn[TheSpaceType] method.)
        /// </summary>
        /// <param name="visitor">Visitor that is stopping on the space</param>
        public override void AcceptStopping(ISpaceVisitor visitor)
        {
            lastDicesValue = visitor.DicesValue;
            base.AcceptStopping(visitor);
        }

    }
}
