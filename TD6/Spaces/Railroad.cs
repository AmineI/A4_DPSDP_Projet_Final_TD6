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
                return rentPrices[getNumberRailroad()];
            }
        }

        public int getNumberRailroad()
        {
            IPlayer player = this.Owner;
            List<Railroad> stations = Game.Instance.Board.FindAllSpaces<Railroad>(railroad => railroad.Owner == player);
            int count = 0;
            foreach (Railroad station in stations)
            {
                count++;
            }
            return count;
        }
    }
}
