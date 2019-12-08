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

        Land ChooseLandToBuild(IPlayer player);
        

        void DisplayMessage(String message);
        void DisplayLands(IPlayer player);
        void DisplayMoney(IPlayer player);

        void ConsoleClear();
    }
}
