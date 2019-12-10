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

        public char DisplayCharacter { get; set; }

        private int currentPosition = 0;
        private int money;
        private int dice1;
        private int dice2;
        private int doubleCount;
        public int CurrentPosition { get => currentPosition; }
        public int Money { get => money; }
        public int DicesValue { get => dice1 + dice2; }

        public bool IsDiceDouble { get => dice1 == dice2; }

        private IBoard gameBoard;
        public List<Property> OwnedProperties { get => gameBoard.FindAllSpaces<Property>(prop => prop.Owner == this); }


        /// <param name="gameBoard">Game Board the player is playing on. Defaults to the Game instance's board.</param>
        public Player(int id, string playerName, int money, char displayCharacter, IBoard gameBoard = null)
        {
            this.Id = id;
            this.PlayerName = playerName;
            this.money = money;
            this.DisplayCharacter = displayCharacter;
            this.gameBoard = gameBoard ?? Game.Instance.Board;

            // The null-coalescing operator ?? returns the value of its left-hand operand if it isn't null; otherwise, it evaluates the right-hand operand and returns its result
        }

        public void RollDices()
        {
            dice1 = Dice.RollDice();
            dice2 = Dice.RollDice();
        }

        public void Pay(int amount, IPlayer destinationPlayer = null)
        {
            money -= amount;
            if (destinationPlayer != null)
            {
                destinationPlayer.Earn(amount);
            }
        }


        public void Earn(int amount)
        {
            money += amount;
        }
        /// <summary>
        /// Function putting the player in a jailed state, using a jailedPlayer decorator
        /// </summary>
        private void GetJailed()
        {
            JailedPlayer jailedPlayer = new JailedPlayer(this);
            Game.ReplaceIPlayerInstances(this, jailedPlayer);
        }
        public void GoToJail()
        {
            //TODO Teleport the player to the Jail space
            this.GetJailed();//Then set it to the jailed state.
        }

        public void GetOutOfJail()
        {
            throw new InvalidOperationException("The player is not in jail.");
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
                if (currentPosition >= gameBoard.Count)
                {//If we are after the end of the board, we go back to the beginning.
                    currentPosition -= gameBoard.Count;
                }
                else if (currentPosition < 0)
                {//If we are before the beginning of the board, we go back to the end of the board.
                    currentPosition += gameBoard.Count;
                }

                //We "visit" the space we just landed on. If the space has an action occuring on walk, it will happen.
                gameBoard[currentPosition].AcceptWalking((ISpaceVisitor)this);
            }
            //Now that we walked the requested distance, 
            //We stop on the space. If the space has an action occuring on stop, it will happen.
            gameBoard[currentPosition].AcceptStopping((ISpaceVisitor)this);
        }

        /// <summary>
        /// Teleport the player on a space, with or without passing through the go space and earning its money
        /// </summary>
        /// <param name="arrival">Destination space</param>
        /// <param name="passThroughGoSpace">True if the user has to pass through the go space while teleporting.</param>
        public void Teleport(IVisitableSpace arrival, bool passThroughGoSpace = false)
        {
            int destinationIndex = gameBoard.IndexOfSpace(arrival);
            if (passThroughGoSpace && destinationIndex < currentPosition)
            {//Some luck cards can teleport us while still going through the Go space.
                //In this case we walk on the Go Space
                gameBoard[0].AcceptWalking((ISpaceVisitor)this);
            }//Whereas the "Go to Jail" event don't
            currentPosition = destinationIndex;
            //Then we stop on the destination Space
            gameBoard[currentPosition].AcceptStopping((ISpaceVisitor)this);
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


        /// <summary>
        /// Function for a player turn, launch dice, move(DiceValue)
        /// </summary>
        public void PlayTurn()
        {
            // We launch the dice with a function 
            RollDices();
            if (IsDiceDouble)
            {
                doubleCount++;
                if (doubleCount == 3)
                {
                    doubleCount = 0;
                    GoToJail();
                    return;
                }
            }
            Move(DicesValue);

            //TODO :

            //if passed by Go ( start )  ( case 0 ) {received 200}
            //do event -> pay rent, buy property, pay tax, receive money
            //do player action, build house etc

            //end play 
            //if double = true 
            // players.PlayTurn;
            if (IsDiceDouble)
            {
                PlayTurn();
            }


            //
        }

    }


}
