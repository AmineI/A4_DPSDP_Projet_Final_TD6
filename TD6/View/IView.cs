﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public interface IView
    {
        bool GetConfirmation(string message = "Do you want to continue ?");
        string GetEnteredString(string message);
        bool GetSaleConfirmation(Property propertyToSell, int priceToSellFor, IPlayer playerToSellTo);
        bool GetPurchaseConfirmation(Property propertyToBuy, int PriceToBuyFor, IPlayer playerToBuyFrom = null);
        bool GetBuildHouseHereConfirmation(Land land);

        Land ChooseLandToBuildOn(IPlayer player);

        T GetObjectChoice<T>(string message, IList<T> choicesList, IList<string> choicesTitlesList = null);


        void DisplayBoard(IGame game, int highlightedSpace = -1);
        void DisplayMessage(String message);
        void DisplayProperties(IPlayer player);
        void DisplayMoney(IPlayer player);
        void DisplayEndGame(IPlayer player);

        void Pause();
        void ClearView();
        int GetEnteredInt(string message = null);

        void EndOfTurnInterface(IGame gameInstance, IPlayer player);
        void SellPropertyInterface(IGame gameInstance, IPlayer player);
        void BuildHouseInterface(IPlayer player);
        void DisplayPlayerLose(IPlayer currentPlayer);
        void DisplayPreTurnInformation(IGame gameInstance, IPlayer currentPlayer);
    }
}
