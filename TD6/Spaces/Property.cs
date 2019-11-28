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

        protected Property(string id, string name, int buyPrice, int[] rentPrice) : base(id, name)
        {
            this.BuyPrice = buyPrice;
            this.rentPrices = rentPrice;
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

        
        // TODO : pour la vente vérifier qu'il n'y a pas de maison sur la propriété
    }
}
