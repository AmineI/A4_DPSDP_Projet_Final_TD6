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
        public override bool CanBeSold { get => true; }

        public static int getNumberOfOwnedRailroads(IPlayer playerOwner)
        {
            List<Railroad> stationsOwnedByPlayer = Game.Instance.Board.FindAllSpaces<Railroad>(railroad => railroad.Owner == playerOwner);
            return stationsOwnedByPlayer.Count;
        }
    }
}
