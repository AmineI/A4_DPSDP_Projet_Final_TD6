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
        public void RentPriceTest_ColorOwnedBySamePlayerWithoutHouseCostDouble()
        {
            Board board = new Board();
            Land landTest1 = new Land("id", "Rue de la paix", Color.Green, 300, new int[] { 50, 100, 140, 250, 300, 450 }, 200, board);
            board.Add(landTest1);
            Land landTest2 = new Land("id2", "Rue 2", Color.Green, 300, new int[] { 50, 100, 140, 250, 300, 450 }, 200, board);
            board.Add(landTest2);
            Player player = new Player(0, "player", 500);
            landTest1.Owner = player;
            landTest2.Owner = player;
            Assert.AreEqual(100, landTest1.RentPrice);
        }

        [TestMethod()]
        public void BuildHouseTest()
        {
            Land landTest = new Land("id", "Rue de la paix", Color.Green, 300, new int[] { 50, 100, 140, 250, 300, 450 }, 200);
            Player p0 = new Player(0, "p0", 500);
            landTest.Owner = p0;
            landTest.BuildHouse();
            Assert.AreEqual(1, landTest.NumberOfHouses);
            Assert.AreEqual(500 - 200, p0.Money);
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