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
            Assert.AreNotEqual(Dice.RollDice(),Dice.RollDice()) ;
        }
    }
}