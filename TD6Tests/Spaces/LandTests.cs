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
        public void getRentPriceTest()
        {
            Land landTest = new Land("id", "Rue de la paix", 300, new int[] { 50, 100, 140, 250, 300, 450 }, Color.Green, 200);
            int rentPrice = landTest.RentPrice;
            Assert.IsTrue(rentPrice == 100);
        }

        [TestMethod()]
        public void BuildHouseTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CanBeSoldTest()
        {
            Land landTest = new Land("id", "Rue de la paix", 300, new int[] { 50, 100, 140, 250, 300, 450 }, Color.Green, 200);
            Assert.IsTrue(landTest.CanBeSold());
            // TODO : vérifier que renvoie false si il y a une maison de construite
        }
    }
}