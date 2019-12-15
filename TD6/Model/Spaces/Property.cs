using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{

    public class OwnerChangeEventArgs : EventArgs
    {
        public IPlayer PreviousOwner { get; set; }
        public IPlayer NewOwner { get; set; }
    }
    public abstract class Property : Space, IVisitableSpace
    {
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

            OwnerChange += Player.UpdatePlayersOwnershipOnLandOwnerChange;
        }


        private IPlayer owner;
        public IPlayer Owner
        {
            get => owner;
            set
            {
                IPlayer previousOwner = owner;
                IPlayer newOwner = value;
                owner = newOwner;
                OnOwnerChange(new OwnerChangeEventArgs { NewOwner = newOwner,PreviousOwner=previousOwner });
            }
        }

        public event EventHandler<OwnerChangeEventArgs> OwnerChange;
        protected virtual void OnOwnerChange(OwnerChangeEventArgs e)
        {
            OwnerChange?.Invoke(this, e);//Calls the subscribed methods, if there are any.
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
