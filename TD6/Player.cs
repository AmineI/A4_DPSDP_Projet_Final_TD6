using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public class Player : IPlayer, ISpaceVisitor
    {
        //TODO jailed decorator( design pattern ) 
        //Auto-properties : Can be publicly accessed but can only be set in the constructor. Id and name never changes so it is fine to use them as auto-properties.
        public int Id { get; }
        /// <summary>
        /// TODO : Find a way to ensure Id uniqueness. Maybe with a sorted collection of players ? 
        /// </summary>
        public string PlayerName { get; }

        private int currentPosition = 0;
        private int money;
        private int dice1;
        private int dice2;
        private int doubleCount;
        public int CurrentPosition { get => currentPosition; }
        public int Money { get => money; }

        /// <summary>
        /// We get the sums of the dices 
        /// </summary>
        public int DiceValue { get => dice1 + dice2; }

        /// <summary>
        /// We check if dices are equal and get the bool value
        /// </summary>
        public bool IsDiceDouble { get => dice1 == dice2; }


        public Player(int id, string playerName, int money)
        {
            this.Id = id;
            this.PlayerName = playerName;
            this.money = money;
        }

        public void RollDices()
        {
            dice1 = Dice.RollDice();
            dice2 = Dice.RollDice();
        }

        /// <summary>
        /// Pay money to someone.
        /// </summary>
        /// <param name="amount">Amount of money to pay</param>
        /// <param name="destinationPlayer">Player to pay. If null, it pays the bank</param>
        public void Pay(int amount, IPlayer destinationPlayer = null)
        {
            money -= amount;
            if (destinationPlayer != null)
            {
                destinationPlayer.Earn(amount);
            }
        }

        /// <summary>
        /// Earn money from someone
        /// </summary>
        /// <param name="amount">amount of money to earn</param>
        public void Earn(int amount)
        {
            money += amount;
        }

        /// <summary>
        /// Moves the player, and walk on each space on the way to the destination, then stop on the destination space. Fires any action due to walking or stopping on a space.
        /// </summary>
        /// <param name="distanceToMove">distance to move, forwards or backwards depending on if it is positive or negative </param>
        public void Move(int distanceToMove)
        {
            //Choose whether to increment or decrement the position depending on the distance to move (positive or negative)
            Action MovePositionByOne;
            if (distanceToMove > 0)
            {
                MovePositionByOne = () => currentPosition++;
            }
            else
            {
                MovePositionByOne = () => currentPosition--;
            }

            for (int step = 0; step < Math.Abs(distanceToMove); step++)
            {
                MovePositionByOne();
                if (currentPosition >= Game.Instance.Board.Count)
                {//If we are after the end of the board, we go back to the beginning.
                    currentPosition -= Game.Instance.Board.Count;
                }
                else if (currentPosition < 0)
                {//If we are before the beginning of the board, we go back to the end of the board.
                    currentPosition += Game.Instance.Board.Count;
                }

                //We "visit" the space we just landed on. If the space has an action occuring on walk, it will happen.
                Game.Instance.Board[currentPosition].AcceptWalking((ISpaceVisitor)this);
            }
            //Now that we walked the requested distance, 
            //We stop on the space. If the space has an action occuring on stop, it will happen.
            Game.Instance.Board[currentPosition].AcceptStopping((ISpaceVisitor)this);
        }

        /// <summary>
        /// Teleport the player on a space, with or without passing through the go space and earning its money
        /// </summary>
        /// <param name="arrival">Destination space</param>
        /// <param name="passThroughGoSpace">True if the user has to pass through the go space while teleporting.</param>
        public void Teleport(IVisitableSpace arrival, bool passThroughGoSpace = false)
        {
            int destinationIndex = Game.Instance.Board.IndexOfSpace(arrival);
            if (passThroughGoSpace && destinationIndex < currentPosition)
            {//Some luck cards can teleport us while still going through the Go space.
                //In this case we walk on the Go Space
                Game.Instance.Board[0].AcceptWalking((ISpaceVisitor)this);
            }//Whereas the "Go to Jail" event don't
            currentPosition = destinationIndex;
            //Then we stop on the destination Space
            Game.Instance.Board[currentPosition].AcceptStopping((ISpaceVisitor)this);
        }

        public void WalkOnProperty(Property property)
        {
            //When you walk on a property, nothing actually happens in the real Monopoly.
            //TODO : We could display the space we walked on, maybe ?
        }

        public void WalkOnEvent(EventSpace eventSpace)
        {
            //We call the walk action delegate of this event space.
            eventSpace.OnWalkAction((IPlayer)this);
        }

        public void StopOnProperty(Property property)
        {
            //TODO : Buy or pay rent.
            throw new NotImplementedException();
        }

        public void StopOnEvent(EventSpace eventSpace)
        {
            //We call the stop action delegate of this event space.
            eventSpace.OnStopAction((IPlayer)this);
        }

        public void GetJailed()
        {
            //TODO 
            JailedPlayer jailedPlayer = new JailedPlayer(this);
            ReplaceInstances(this, jailedPlayer);
        }

        /// <summary>
        /// Replace all instances of a player to another. For example, in order to replace all instances of a Player to a JailedPlayer.
        /// </summary>
        /// <param name="oldPlayer">old IPlayer instance to replace</param>
        /// <param name="newPlayer">new IPlayer instance to put in place of the old one</param>
        public static void ReplaceInstances(IPlayer oldPlayer, IPlayer newPlayer)
        {
            //Replace the player from the player list
            int playerIndex = Game.Instance.Players.IndexOf(oldPlayer);
            Game.Instance.Players[playerIndex] = newPlayer;

            //Replace the player instance from his owned properties
            foreach (Property ownedProperty in oldPlayer.OwnedProperties)
            {
                ownedProperty.Owner = newPlayer;
            }
            //TODO : Replace the instance in any other field it may be added on later.
        }

        /// <summary>
        /// Function for a player turn, launch dice, move(DiceValue)
        /// </summary>
        public void PlayTurn()
        {
            //TODO Decorator for jail 
            //We are not in jail in this fonction 

            //launch dice
            RollDices();

            if (IsDiceDouble)
            {
                doubleCount++;
                if (doubleCount == 3)
                {
                    doubleCount = 0;
                    //TODO Go to jail
                }
            }
            Move(DiceValue);
            //TODO :
            //Moveplayer on board
            //if passed by Go ( start )  ( case 0 ) {received 200}
            //do event -> pay rent, buy property, pay tax, receive money
            //do player action, build house etc

            //Check bankrupt

            //end play 
            //if double = true 
            // players.PlayTurn;



            //
        }
    }


}
