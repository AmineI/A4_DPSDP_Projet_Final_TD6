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
        bool GetBuildHouseHereConfirmation(Land land);
        bool GetBuildHouseConfirmation();

        Land ChooseLandToBuildOn(IPlayer player);

        void DisplayMessage(String message);
        void DisplayLands(IPlayer player);
        void DisplayMoney(IPlayer player);
        void DisplayEndGame(IPlayer player);

        void ClearView();
    }
}
