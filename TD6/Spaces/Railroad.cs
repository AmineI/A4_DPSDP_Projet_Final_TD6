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
        public Railroad(string id, string name, int buyPrice, int[] rentPrices) : base(id, name, buyPrice, rentPrices)
        {
        }

        public override int RentPrice { get => rentPrices[GetNumberOfOwnedRailroads(this.Owner)]; }

        // A railroad can always be sold
        public override bool CanBeSold { get => true; }

        public static int GetNumberOfOwnedRailroads(IPlayer playerOwner)
        {
            List<Railroad> stationsOwnedByPlayer = Game.Instance.Board.FindAllSpaces<Railroad>(railroad => railroad.Owner == playerOwner);
            return stationsOwnedByPlayer.Count;
        }
    }
}
