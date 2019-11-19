using Microsoft.VisualStudio.TestTools.UnitTesting;
using TD6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6.Tests
{
    [TestClass()]
    public class DeTests
    {
        [TestMethod()]
        public void RollDiceTest()
        {
            int diceResult;
            for(int i = 0; i < 60; i++)
            {
                diceResult = Dice.RollDice();
                Assert.IsTrue(diceResult>=1 && diceResult<=6);
            }
            //Todo change the test, random could be the same. Check the range maybe ?
            Assert.AreNotEqual(Dice.RollDice(),Dice.RollDice()) ;
        }
    }
}