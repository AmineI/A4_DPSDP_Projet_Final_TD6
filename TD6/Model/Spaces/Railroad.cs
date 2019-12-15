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
            return playerOwner.OwnedProperties.OfType<Railroad>().Count();
        }

        public override string ToString()
        {
            if (Owner == null)
            {
                return $"Railroad {Name}, owned by the bank, buy price of {BuyPrice}$";
            }
            else
            {
                return $"Railroad {Name}, owned by {Owner}, rent price of {RentPrice}$";
            }
        }
    }
}
