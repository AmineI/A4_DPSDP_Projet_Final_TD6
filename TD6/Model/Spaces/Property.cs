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
        public virtual IPlayer Owner
        {
            get => owner;
            set => owner = value;
        }

        /// <summary>
        /// Price at which a player can buy the house from the bank
        /// </summary>
        public int BuyPrice { get; }

        /// <summary>
        /// list of rent prices according to a parameter : for example the number of houses on a land, or the number of owned railroads.
        /// </summary>
        protected int[] rentPrices;

        /// <summary>
        /// Property to get the current RentPrice.
        /// </summary>
        public abstract int RentPrice { get; }

        /// <summary>
        /// A boolean representing if a property can be sold to another player
        /// </summary>
        public abstract bool CanBeSold { get; }

        public virtual Color Color { get => Color.White; }

        protected Property(string id, string name, int buyPrice, int[] rentPrices, IBoard board) : base(id, name, board)
        {
            this.BuyPrice = buyPrice;
            this.rentPrices = rentPrices;
        }

        public virtual void AcceptWalking(ISpaceVisitor visitor)
        {
            visitor.WalkOnProperty(this);
        }

        public virtual void AcceptStopping(ISpaceVisitor visitor)
        {
            visitor.StopOnProperty(this);
        }

    }
}
