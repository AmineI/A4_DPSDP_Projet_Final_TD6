using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    abstract class Property : Space
    {
        private Player owner;
        public int BuyPrice { get; }
        protected int[] rentPrice;

        public abstract int RentPrice
        {
            get;
        }

        public Property(string id, string name, int buyPrice, int[] rentPrice) : base(id, name)
        {
            this.BuyPrice = buyPrice;
            this.rentPrice = rentPrice;
        }
        
    }
}
