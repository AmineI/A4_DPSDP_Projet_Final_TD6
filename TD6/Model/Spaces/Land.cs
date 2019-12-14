using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public enum Color { White, Gray, Brown, Cyan, Purple, Orange, Red, Yellow, Green, Blue };

    public class Land : Property
    {
        public override Color Color { get; }
        private int numberOfHouses = 0;
        public int NumberOfHouses { get => numberOfHouses; }

        public int HousePrice { get; }

        /// <param name="rentPrice">rent price list according to the number of houses built on the land. Up to 6 houses.</param>
        public Land(string id, string name, Color color, int buyPrice, int[] rentPrices, int housePrice, IBoard board = null) : base(id, name, buyPrice, rentPrices, board)
        {
            this.HousePrice = housePrice;
            this.Color = color;
        }

        public override int RentPrice
        {
            get => GetRentPrice();
        }

        ///A land can be sold only if there is no house on it
        public override bool CanBeSold => numberOfHouses == 0;


        /// <summary>
        /// A boolean indicating if this land is in a monopoly (ie all lands of that color group are owned by the same player) or not
        /// </summary>
        public bool IsInMonopoly { get => IsColorMonopolized(this.Color, this.board); }

        /// <summary>
        /// This function gives the rent of the land based on the number of houses and land owned by the land owner.
        /// </summary>
        /// <returns> An integer representing the price of rent</returns>
        public int GetRentPrice()
        {
            //We get the base rent price according to the number of houses
            int rentPrice = rentPrices[numberOfHouses];

            if (this.IsInMonopoly && this.numberOfHouses == 0)
            {//If a land is in a monopoly, the rent is doubled on all unimproved lots of that color group.
                rentPrice *= 2;
            }
            return rentPrice;
        }

        /// <summary>
        /// Check if a given color group is monopolized, ie all lands of that color group are owned by the same player
        /// </summary>
        /// <param name="color">Color of the group we want to check</param>
        /// <param name="board">Board we are checking against. Default to the game board</param>
        /// <returns>true if the color group is monopolized (owned by the same player), false otherwise.</returns>
        public static bool IsColorMonopolized(Color color, IBoard board)
        {
            //We gather the list of lands from that color group.
            List<Land> sameColorLands = board.FindAllSpaces<Land>(land => land.Color == color);

            //We get the owner of the first land of that color.
            IPlayer firstLandOwner = sameColorLands.First<Land>().Owner;
            if (firstLandOwner == null)
            {
                return false;
            }
            //And then check if he owns all the lands of that color. If he does, the color is in a monopoly.
            return sameColorLands.All(land => land.Owner == firstLandOwner);
        }

        /// <summary>
        /// Builds a house on the land, and make the owner pay for the construction.
        /// </summary>
        public void BuildHouse()
        {
            this.Owner?.Pay(HousePrice);//If the owner is not null, it pays the price.
            numberOfHouses++;//A house is built regardless, in case an extension is made where the bank builds a house for example.
        }

        /// <summary>
        /// Checks if the player can build a house on this land.
        /// </summary>
        /// <returns>A boolean true if </returns>
        public bool IsHouseBuildable()
        {
            //The maximum number of houses on this land is 5, with 5 being a hostel. 
            if (this.NumberOfHouses >= 5) { return false; }//In this case we immediately return, no need to check all the lands of the color group.

            List<Land> sameColorLands = board.FindAllSpaces<Land>(land => land.Color == this.Color);

            return sameColorLands.All<Land>(land => land.Owner == this.Owner //All lands in the color group have to be owned by the same player
                                             && land.NumberOfHouses >= this.NumberOfHouses);//And all lands in the color group must have more houses than this land.

            //You can only build a house on the land with the fewest houses of the color group, and you have to own all the lands of the color group.");
        }

        public override string ToString()
        {
            if (Owner == null)
            {
                return $"{Color} land, {Name}, owned by the bank, buy price of {BuyPrice}$";
            }
            else
            {
                return $"{Color} land, {Name}, owned by {Owner}, rent price of {RentPrice}$";
            }
        }

    }
}
