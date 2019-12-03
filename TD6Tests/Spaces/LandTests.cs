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
    public class LandTests
    {
        [TestMethod()]
        public void LandTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RentPriceTest()
        {
            //TODO : Adapt this when the builder pattern is done to generate a board.
            //TODO : Even better, try to look at the dependency injection pattern in order to use stubs in tests.
            Land landTest = new Land("id", "Rue de la paix", Color.Green, 300, new int[] { 50, 100, 140, 250, 300, 450 }, 200);
            Assert.AreEqual(100, landTest.RentPrice);
        }

        [TestMethod()]
        public void BuildHouseTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CanBeSoldTest_LandsWithoutHousesCanBeSold()
        {
            Land landTest = new Land("id", "Rue de la paix", Color.Green, 300, new int[] { 50, 100, 140, 250, 300, 450 }, 200);
            Assert.IsTrue(landTest.CanBeSold);
        }
        [TestMethod()]
        public void CanBeSoldTest_LandsWithHousesCantBeSold()
        {
            Land landTest = new Land("id", "Rue de la paix", Color.Green, 300, new int[] { 50, 100, 140, 250, 300, 450 }, 200);
            landTest.BuildHouse();
            Assert.IsFalse(landTest.CanBeSold);
        }
    }
}