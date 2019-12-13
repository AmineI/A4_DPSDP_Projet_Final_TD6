using Microsoft.VisualStudio.TestTools.UnitTesting;
using TD6;
using System;
using TD6.Fakes;

namespace TD6.Tests
{
    [TestClass()]
    public class PlayerTests
    {

        /// <summary>
        /// Creates a stub board board with 40 spaces : a Go Space giving 200 $ to any player walking on it, and 39 other spaces that are empty and do nothing.
        /// </summary>
        /// <returns></returns>
        private static StubIBoard CreateStubBoardWithOnlyGoSpaceGiving200OnWalk()
        {
            IVisitableSpace goSpace = new EventSpace("GO_SPACE", "Go", onStopAction: null, onWalkAction: (player) => player.Earn(200));
            IVisitableSpace blankSpace = new EventSpace("BLANK", "Blank", null);

            var stubBoard = new Fakes.StubIBoard()
            {
                ItemGetInt32 = (key) =>//Any space besides 0 is a blank useless space.
                {
                    if (key >= 40 || key < 0) { throw new ArgumentOutOfRangeException(); }
                    if (key == 0)
                    {
                        return goSpace;
                    }
                    else
                    {
                        return blankSpace;
                    }
                },
                GoSpaceGet = () => goSpace,
                CountGet = () => 40,//The Count will always return 40
                IndexOfSpaceIVisitableSpace = (space) =>
                {
                    if (space == goSpace) { return 0; }
                    else { return 1; };
                }
            };

            return stubBoard;
        }

        /// <summary>
        /// Creates a stub view that does not wait for user input or pause.
        /// </summary>
        /// <returns></returns>
        private static StubIView CreateStubViewSkippingUserInputAndPauses()
        {
            //Create a stub view so that it is not waiting for a user input or pausing, since we are in a test.
            var stubView = new Fakes.StubIView()
            {
                Pause = () => { }//Pause does nothing now. 
            };
            return stubView;
        }

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
            StubIBoard stubBoard = CreateStubBoardWithOnlyGoSpaceGiving200OnWalk();
            Game.Instance.InitializeBoard(stubBoard);

            StubIView stubView = CreateStubViewSkippingUserInputAndPauses();
            Game.Instance.View = stubView;


            Player p0 = new Player(0, "P0", 1500, 'x', Game.Instance);
            Assert.AreEqual(0, p0.CurrentPosition);

            p0.Move(5);

            Assert.AreEqual(5, p0.CurrentPosition);
            Assert.AreEqual(1500, p0.Money);
        }

        [TestMethod()]
        public void MoveTest_DestinationReachedWhilePassingGo()
        {
            StubIBoard stubBoard = CreateStubBoardWithOnlyGoSpaceGiving200OnWalk();
            Game.Instance.InitializeBoard(stubBoard);

            StubIView stubView = CreateStubViewSkippingUserInputAndPauses();
            Game.Instance.View = stubView;


            Player p0 = new Player(0, "P0", 1500, 'x', Game.Instance);
            Assert.AreEqual(0, p0.CurrentPosition);

            p0.Move(Game.Instance.Board.Count + 5);

            Assert.AreEqual(5, p0.CurrentPosition);
            Assert.AreEqual(1700, p0.Money);
        }

        [TestMethod()]
        public void TeleportTest_WithoutPassingGo()
        {
            StubIBoard stubBoard = CreateStubBoardWithOnlyGoSpaceGiving200OnWalk();
            Game.Instance.InitializeBoard(stubBoard);

            StubIView stubView = CreateStubViewSkippingUserInputAndPauses();
            Game.Instance.View = stubView;


            Player p0 = new Player(0, "P0", 1500, 'x', Game.Instance);
            Assert.AreEqual(0, p0.CurrentPosition);

            p0.Move(5);
            Assert.AreEqual(5, p0.CurrentPosition);

            p0.Teleport(stubBoard.GoSpaceGet(), false);

            Assert.AreEqual(0, p0.CurrentPosition);
            Assert.AreEqual(1500, p0.Money);
        }
        [TestMethod()]
        public void TeleportTest_PassingGo()
        {
            StubIBoard stubBoard = CreateStubBoardWithOnlyGoSpaceGiving200OnWalk();
            Game.Instance.InitializeBoard(stubBoard);

            StubIView stubView = CreateStubViewSkippingUserInputAndPauses();
            Game.Instance.View = stubView;


            Player p0 = new Player(0, "P0", 1500, 'x', Game.Instance);
            Assert.AreEqual(0, p0.CurrentPosition);

            p0.Move(5);
            Assert.AreEqual(5, p0.CurrentPosition);

            p0.Teleport(stubBoard.GoSpaceGet(), true);

            Assert.AreEqual(0, p0.CurrentPosition);
            Assert.AreEqual(1700, p0.Money);
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