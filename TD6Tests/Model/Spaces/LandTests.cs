using Microsoft.VisualStudio.TestTools.UnitTesting;
using TD6;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public void IsHouseBuildable_FalseWhenNotInMonopoly()
        {
            Board board = new Board();
            Land landTest1 = new Land("id1", "Rue de la paix", Color.Green, 300, new int[] { 50, 100, 140, 250, 300, 450 }, 200, board);
            board.Add(landTest1);
            Land landTest2 = new Land("id2", "2e Rue de la paix", Color.Green, 300, new int[] { 50, 100, 140, 250, 300, 450 }, 200, board);
            board.Add(landTest2);
            Player p0 = new Player(0, "p0", 500);
            landTest1.Owner = p0;

            Assert.IsFalse(landTest1.IsHouseBuildable());
        }

        [TestMethod()]
        public void IsHouseBuildable_TrueWhenInMonopolyAndNoHouses()
        {
            Board board = new Board();
            Land landTest1 = new Land("id1", "Rue de la paix", Color.Green, 300, new int[] { 50, 100, 140, 250, 300, 450 }, 200, board);
            board.Add(landTest1);
            Land landTest2 = new Land("id2", "2e Rue de la paix", Color.Green, 300, new int[] { 50, 100, 140, 250, 300, 450 }, 200, board);
            board.Add(landTest2);
            Player p0 = new Player(0, "p0", 500);
            landTest1.Owner = p0;
            landTest2.Owner = p0;

            Assert.IsTrue(landTest1.IsHouseBuildable() && landTest2.IsHouseBuildable());
        }
        [TestMethod()]
        public void IsHouseBuildable_TrueWhenInMonopolyOnlyForLowestNumberOfHouses()
        {
            Board board = new Board();
            Land landTest1 = new Land("id1", "Rue de la paix", Color.Green, 300, new int[] { 50, 100, 140, 250, 300, 450 }, 200, board);
            board.Add(landTest1);
            Land landTest2 = new Land("id2", "2e Rue de la paix", Color.Green, 300, new int[] { 50, 100, 140, 250, 300, 450 }, 200, board);
            board.Add(landTest2);
            Player p0 = new Player(0, "p0", 500);
            landTest1.Owner = p0;
            landTest2.Owner = p0;
            landTest1.BuildHouse();

            Assert.IsFalse(landTest1.IsHouseBuildable());
            Assert.IsTrue(landTest2.IsHouseBuildable());
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


        [TestMethod()]
        public void IsInMonopolyTest()
        {
            Board board = new Board();
            List<Land> my3GreenLands = new List<Land>() {
                new Land("id1", "Rue de la paix", Color.Green, 300, new int[] { 50, 100, 140, 250, 300, 450 }, 200, board),
                new Land("id2", "2e Rue de la paix", Color.Green, 300, new int[] { 50, 100, 140, 250, 300, 450 }, 200, board),
                new Land("id3", "3e Rue de la paix", Color.Green, 300, new int[] { 50, 100, 140, 250, 300, 450 }, 200, board)
            };
            my3GreenLands.ForEach(land => board.Add(land));

            Land brownLand = new Land("id4", "Une rue marron", Color.Brown, 300, new int[] { 50, 100, 140, 250, 300, 450 }, 200, board);
            board.Add(brownLand);

            Assert.IsFalse(my3GreenLands.Any(land => land.IsInMonopoly));
            //These lands have no owner, so none of these should be in monopoly.

            Player p0 = new Player(0, "p0", 500);
            Player p1 = new Player(1, "p0", 500);


            my3GreenLands.ForEach(land => land.Owner = p1);

            Assert.IsTrue(my3GreenLands.All(land => land.IsInMonopoly));//All green lands should be in monopoly.
            Assert.IsFalse(brownLand.IsInMonopoly);


            my3GreenLands[0].Owner = p0;

            Assert.IsFalse(my3GreenLands.Any(land => land.IsInMonopoly));//One green lands does not belong to p0 so they are not in monopoly.
            Assert.IsFalse(brownLand.IsInMonopoly);
        }

    }
}