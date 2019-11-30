using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public class Railroad : Property
    {
        public Railroad(string id, string name, int buyPrice, int[] rentPrice) : base(id, name, buyPrice, rentPrice)
        {
        }

        public override int RentPrice
        {
            get
            {
                return rentPrices[getNumberOfOwnedRailroads(this.Owner)];
            }
        }

        public static int getNumberOfOwnedRailroads(IPlayer playerOwner)
        {
            List<Railroad> stationsOwnedByPlayer = Game.Instance.Board.FindAllSpaces<Railroad>(railroad => railroad.Owner == playerOwner);
            return stationsOwnedByPlayer.Count;
        }

        /// <summary>
        /// A railroad can always be sold, so return true
        /// </summary>
        /// <returns> Return true</returns>
        public override bool CanBeSold()
        {
            return true;
        }
    }
}
