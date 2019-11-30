using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public abstract class Property : Space, IVisitableSpace
    {
        private IPlayer owner;
        public int BuyPrice { get; }
        protected int[] rentPrices;

        public abstract int RentPrice
        {
            get;
        }

        protected Property(string id, string name, int buyPrice, int[] rentPrices) : base(id, name)
        {
            this.BuyPrice = buyPrice;
            this.rentPrices = rentPrices;
        }


        public IPlayer Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public void AcceptWalking(ISpaceVisitor visitor)
        {
            visitor.WalkOnProperty(this);
        }

        public void AcceptStopping(ISpaceVisitor visitor)
        {
            visitor.StopOnProperty(this);
        }
        
        /// <summary>
        /// Return a boolean representing if a property can be sold
        /// </summary>
        /// <returns> a boolean representinf if this property can be sold</returns>
        public abstract bool CanBeSold();
    }
}
