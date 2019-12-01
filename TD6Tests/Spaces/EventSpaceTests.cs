using Microsoft.VisualStudio.TestTools.UnitTesting;
using TD6;
using System;

namespace TD6.Tests
{
    [TestClass()]
    public class EventSpaceTests
    {

        [TestMethod()]
        public void EventSpaceTest_PartialConstructor()
        {
            Action<IPlayer> pay200 = delegate (IPlayer player) { player.Pay(200); };
            EventSpace loseMoneyEventSpace = new EventSpace("NOLUCK", "Bad luck space", onStopAction: pay200);
            Assert.AreEqual("NOLUCK", loseMoneyEventSpace.Id);
            Assert.AreEqual("Bad luck space", loseMoneyEventSpace.Name);
            Assert.AreEqual(pay200, loseMoneyEventSpace.OnStopAction);
            Assert.AreEqual(EventSpace.NoAction, loseMoneyEventSpace.OnWalkAction);
        }

        [TestMethod()]
        public void EventSpaceTest_FullConstructor()
        {
            Action<IPlayer> pay100 = delegate (IPlayer player) { player.Pay(100); };
            Action<IPlayer> pay200 = delegate (IPlayer player) { player.Pay(200); };
            EventSpace loseMoneyEventSpace = new EventSpace("NOLUCK", "Bad luck space", onStopAction: pay200, onWalkAction: pay100);
            Assert.AreEqual("NOLUCK", loseMoneyEventSpace.Id);
            Assert.AreEqual("Bad luck space", loseMoneyEventSpace.Name);
            Assert.AreEqual(pay100, loseMoneyEventSpace.OnWalkAction);
            Assert.AreEqual(pay200, loseMoneyEventSpace.OnStopAction);
        }

        [TestMethod()]
        public void ActionTest_ReturnsNoActionWhenNull()
        {
            EventSpace loseMoneyEventSpace = new EventSpace("NOLUCK", "Bad luck space", onStopAction: null, onWalkAction: null);
            Assert.AreEqual(EventSpace.NoAction, loseMoneyEventSpace.OnWalkAction);
            Assert.AreEqual(EventSpace.NoAction, loseMoneyEventSpace.OnStopAction);
        }

        /// <summary>
        /// Checks if the corresponding action is correctly called when a player walks on the event space.
        /// </summary>
        [TestMethod()]
        public void AcceptWalkingTest()
        {
            Action<IPlayer> pay100 = delegate (IPlayer player) { player.Pay(100); };
            EventSpace loseMoneyEventSpace = new EventSpace("NOLUCK", "Bad luck space", onStopAction: null, onWalkAction: pay100);
            Player player1 = new Player(0, "player", 200);
            loseMoneyEventSpace.AcceptWalking(player1);
            Assert.AreEqual(200 - 100, player1.Money);
        }

        /// <summary>
        /// Checks if the corresponding action is correctly called when a player stops on the event space.
        /// </summary>
        [TestMethod()]
        public void AcceptStoppingTest()
        {
            Action<IPlayer> pay100 = delegate (IPlayer player) { player.Pay(100); };
            EventSpace loseMoneyEventSpace = new EventSpace("NOLUCK", "Bad luck space", onStopAction: pay100);
            Player player1 = new Player(0, "player", 200);
            loseMoneyEventSpace.AcceptStopping(player1);
            Assert.AreEqual(200 - 100, player1.Money);
        }

    }
}