using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public abstract class Property : Space
    {
        private IPlayer owner;
        public int BuyPrice { get; }
        protected int[] rentPrices;

        public abstract int RentPrice
        {
            get;
        }

        protected Property(string id, string name, int buyPrice, int[] rentPrice) : base(id, name)
        {
            this.BuyPrice = buyPrice;
            this.rentPrices = rentPrice;
        }

        public IPlayer Owner
        {
            get;
        }

        /// <summary>
        /// Makes sure there isn't already an owner and adds the new owner
        /// </summary>
        /// <param name="player"> the player who wants to buy this property</param>
        public void setOwner(IPlayer player)
        {
            if (this.Owner == null)
            {
                this.owner = player;
            }
            // I think we will check that the property does not belong to anyone before calling this function.
            // But I prefere let it here
            else
            {
                Console.WriteLine("This property already belongs to " + this.Owner + ".");
            }
        }
    }
}
