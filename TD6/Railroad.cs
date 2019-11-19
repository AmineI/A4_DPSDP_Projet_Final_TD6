using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    class Railroad : Property
    {
        public Railroad(string id, string name, int buyPrice, int[] rentPrice) : base(id, name, buyPrice, rentPrice)
        {
        }

        // TODO : le RentPrice
        public override int RentPrice
        {
            get;
        }
    }
}
