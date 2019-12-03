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
            Land landTest = new Land("id", "Rue de la paix", Color.Green, 300, new int[] { 50, 100, 140, 250, 300, 450 }, 200);
            Assert.AreEqual(100, landTest.RentPrice);
        }

        [TestMethod()]
        public void BuildHouseTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CanBeSoldTest()
        {
            // TODO : vérifier que renvoie false si il y a une maison de construite
            Land landTest = new Land("id", "Rue de la paix", Color.Green, 300, new int[] { 50, 100, 140, 250, 300, 450 }, 200);
            Assert.IsTrue(landTest.CanBeSold);
        }
    }
}