using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    class Land : Property
    {
        public Land(string id, string name, int buyPrice, int[] rentPrice) : base(id, name, buyPrice, rentPrice)
        {
        }

        // TODO : le RentPrice de Land
        public override int RentPrice
        {
            get;
        }
    }
}
