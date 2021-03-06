﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TD6;
using System;

namespace TD6.Tests
{
    [TestClass()]
    public class RailroadTests
    {
        /// <summary>
        /// Test the number of railroad owned by the player
        /// </summary>
        [TestMethod()]
        public void GetNumberOfOwnedRailroadsTest()
        {
            Board board = new Board();
            Railroad railroad1 = new Railroad("RAILROAD1", "First Railroad", 50, new int[] { 50, 100, 150, 200 }, board);
            board.Add(railroad1);
            Railroad railroad2 = new Railroad("RAILROAD2", "Second Railroad", 50, new int[] { 50, 100, 150, 200 }, board);
            board.Add(railroad2);
            Railroad railroad3 = new Railroad("RAILROAD3", "Third Railroad", 50, new int[] { 50, 100, 150, 200 }, board);
            board.Add(railroad3);
            Player player = new Player(0, "player", 500);
            Assert.AreEqual(0, Railroad.GetNumberOfOwnedRailroads(player, board));
            railroad1.Owner = player;
            Assert.AreEqual(1, Railroad.GetNumberOfOwnedRailroads(player, board));
            railroad2.Owner = player;
            Assert.AreEqual(2, Railroad.GetNumberOfOwnedRailroads(player, board));
            railroad3.Owner = player;
            Assert.AreEqual(3, Railroad.GetNumberOfOwnedRailroads(player, board));
        }

        /// <summary>
        /// Test if the rent price of a railroad depends on the number of stations owned by the owner
        /// </summary>
        [TestMethod()]
        public void RentPriceTest()
        {
            Board board = new Board();
            Railroad railroad1 = new Railroad("RAILROAD1", "First Railroad", 50, new int[] { 50, 100, 150, 200 }, board);
            board.Add(railroad1);
            Railroad railroad2 = new Railroad("RAILROAD2", "Second Railroad", 50, new int[] { 50, 100, 150, 200 }, board);
            board.Add(railroad2);
            Railroad railroad3 = new Railroad("RAILROAD3", "Third Railroad", 50, new int[] { 50, 100, 150, 200 }, board);
            board.Add(railroad3);
            Player player = new Player(0, "player", 500);
            Assert.AreEqual(0, railroad1.RentPrice);
            railroad1.Owner = player;
            Assert.AreEqual(50, railroad1.RentPrice);
            railroad2.Owner = player;
            Assert.AreEqual(100, railroad1.RentPrice);
            railroad3.Owner = player;
            Assert.AreEqual(150, railroad1.RentPrice);
        }
    }
}