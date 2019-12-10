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
    public class RailroadTests
    {
        [TestMethod()]
        public void RailroadTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetNumberOfOwnedRailroadsTest()
        {
            Board board = new Board();
            Railroad railroad1 = new Railroad("RAILROAD1", "First Railroad", 50, new int[] { 50, 100, 150, 200}, board);
            board.Add(railroad1);
            Railroad railroad2 = new Railroad("RAILROAD2", "Second Railroad", 50, new int[] { 50, 100, 150, 200}, board);
            board.Add(railroad2);
            Railroad railroad3 = new Railroad("RAILROAD3", "Third Railroad", 50, new int[] { 50, 100, 150, 200}, board);
            board.Add(railroad3);
            Player player = new Player(0, "player", 500, board);
            railroad1.Owner = player;
            railroad2.Owner = player;
            railroad3.Owner = player;
            Assert.IsTrue(Railroad.GetNumberOfOwnedRailroads(player, board) == 3);
        }
    }
}