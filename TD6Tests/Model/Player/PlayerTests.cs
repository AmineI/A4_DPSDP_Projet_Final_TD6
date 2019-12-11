using Microsoft.VisualStudio.TestTools.UnitTesting;
using TD6;
using System;

namespace TD6.Tests
{
    [TestClass()]
    public class PlayerTests
    {

        /// <summary>
        /// Tests the constructor of a player
        /// </summary>
        [TestMethod()]
        public void PlayerTest()
        {
            Player player1 = new Player(0, "player", 200);
            Assert.AreEqual(0, player1.Id);
            Assert.AreEqual("player", player1.PlayerName);
            Assert.AreEqual(200, player1.Money);
        }

        /// <summary>
        /// Tests if the RollDices() function changed the DiceValue
        /// </summary>
        [TestMethod()]
        public void RollDicesTest()
        {
            Player player1 = new Player(0, "player", 200);
            player1.RollDices();
            Assert.IsTrue(player1.DicesValue > 0);
        }

        /// <summary>
        /// Check if paying the bank does remove the amount from the player's money.
        /// </summary>
        [TestMethod()]
        public void PayTest_PayBank()
        {
            Player player1 = new Player(0, "player", 200);
            player1.Pay(100);
            Assert.AreEqual(200 - 100, player1.Money);
        }

        /// <summary>
        /// Check if paying a user does remove the amount from the paying player's money and adds it to the receiver player.
        /// </summary>
        [TestMethod()]
        public void PayTest_PaySomeone()
        {
            Player player1 = new Player(0, "player1", 200);
            Player player2 = new Player(1, "player2", 200);
            player1.Pay(200, player2);
            Assert.AreEqual(0, player1.Money);
            Assert.AreEqual(400, player2.Money);
        }

        /// <summary>
        /// Checks if earning money properly adds it to the player's balance
        /// </summary>
        [TestMethod()]
        public void EarnTest()
        {
            Player player1 = new Player(0, "player", 200);
            player1.Earn(200);
            Assert.AreEqual(400, player1.Money);
        }

        [TestMethod()]
        public void MoveTest_DestinationReachedWithoutPassingGo()
        {
            //TODO : Verifier si le joueur est bien arrivé sur la case de destination, dans le cas d'un déplacement ou la case départ n'est pas dépassée
        }
        [TestMethod()]
        public void MoveTest_WithoutPassingGo()
        {
            //TODO : Verifier si le joueur est bien arrivé sur la case de destination, dans le cas d'un déplacement ou la case départ n'est pas dépassée
        }
        [TestMethod()]
        public void MoveTest_DestinationReachedWhilePassingGo()
        {
            //TODO : Verifier si le joueur est bien arrivé sur la case de destination, dans la cas d'un déplacement passant par la case départ.
            //Verifier également si le joueur a gagné l'argent du passage par la case départ.
        }

        [TestMethod()]
        public void TeleportTest_WithoutPassingGo()
        {
            //TODO : Verifier si le joueur est bien arrivé sur la case de destination, dans le cas d'un déplacement ou la case départ n'est pas dépassée
        }
        [TestMethod()]
        public void TeleportTest_PassingGo()
        {
            //TODO : Verifier si le joueur est bien arrivé sur la case de destination, dans la cas d'un déplacement passant par la case départ.
            //Verifier également si le joueur a gagné l'argent du passage par la case départ.

            //TODO : Verifier si le joueur est bien arrivé sur la case de destination, dans la cas d'un déplacement faisant le tour du plateau mais sans passer par la case départ ( cf argument)
            //Verifier également si le joueur a gagné l'argent du passage par la case départ.

        }

        /// <summary>
        /// Checks if the corresponding action is correctly called when walking on an event space.
        /// </summary>
        [TestMethod()]
        public void WalkOnEventTest()
        {
            Action<IPlayer> pay100 = delegate (IPlayer player) { player.Pay(100); };
            EventSpace loseMoneyEventSpace = new EventSpace("NOLUCK", "Bad luck space", onStopAction: null, onWalkAction: pay100);
            Player player1 = new Player(0, "player", 200);
            player1.WalkOnEvent(loseMoneyEventSpace);
            Assert.AreEqual(200 - 100, player1.Money);
        }
        /// <summary>
        /// Checks if the corresponding action is correctly called when stopping on an event space.
        /// </summary>
        [TestMethod()]
        public void StopOnEventTest()
        {
            Action<IPlayer> pay100 = delegate (IPlayer player) { player.Pay(100); };
            EventSpace loseMoneyEventSpace = new EventSpace("NOLUCK", "Bad luck space", onStopAction: pay100);
            Player player1 = new Player(0, "player", 200);
            player1.StopOnEvent(loseMoneyEventSpace);
            Assert.AreEqual(200 - 100, player1.Money);
        }
        //TODO Tests for properties.
    }
}