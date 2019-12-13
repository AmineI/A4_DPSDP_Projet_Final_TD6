using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace TD6
{
    public class Railroad : Property
    {
        /// <param name="rentPrice">rent price list according to the number of railroads owned by the same player.</param>
        public Railroad(string id, string name, int buyPrice, int[] rentPrices, IBoard board = null) : base(id, name, buyPrice, rentPrices, board)
        {
        }

        public override int RentPrice { get => Owner == null ? 0 : rentPrices[GetNumberOfOwnedRailroads(this.Owner, this.board) - 1]; }
        //0 if the owner is null, otherwise we get the actual rent price.

        public override Color Color => Color.Gray;

        // A railroad can always be sold
        public override bool CanBeSold { get => true; }

        public static int GetNumberOfOwnedRailroads(IPlayer playerOwner, IBoard board)
        {
            List<Railroad> stationsOwnedByPlayer = board.FindAllSpaces<Railroad>(railroad => railroad.Owner == playerOwner);
            return stationsOwnedByPlayer.Count;
        }
        public override string ToString()
        {
            if (Owner == null)
            {
                return $"{Name},nobody owns this railroad, the buy price is {BuyPrice}$";
            }
            else
            {
                return $"{Name},his owner is {Owner},the rent price is {RentPrice}$";
            }
        }
    }
}
