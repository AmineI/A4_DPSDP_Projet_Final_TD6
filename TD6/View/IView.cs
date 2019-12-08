using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6.View
{
    public interface IView
    {
        bool GetSaleConfirmation(Property property);
        bool GetPurchaseConfirmation(Property property);
        bool GetBuildHouseConfirmation(Land land);

        void DisplayMessage(String message);


    }
}
