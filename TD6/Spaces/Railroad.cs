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
                List<Railroad> stations = Board.FindAllSpaces<Railroad>(railroad => railroad.Owner == this.Owner);
                int count = 0;
                foreach (Railroad station in stations)
                {
                    count++;
                }
                return rentPrices[count];
            }
        }
    }
}
