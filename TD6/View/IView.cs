using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6.View
{
    public interface IView
    {
        void ConfirmationSale(Property property);
        void ConfirmationPurchase(Property property);

    }
}
