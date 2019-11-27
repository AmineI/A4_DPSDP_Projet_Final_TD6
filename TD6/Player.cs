using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public class Player : IPlayer
    {
        //TODO jailed decorator( design pattern ) 
        private int id;
        private string playerName;
        private int currentPosition = 0;
        private int money;
        private int dice1;
        private int dice2;
        private int doubleCount;
        public Player(int id, string playerName, int money)
        {
            this.id = id;
            this.playerName = playerName;
            this.money = money;

        }
        public void RollDices()
        {
            dice1 = Dice.RollDice();
            dice2 = Dice.RollDice();
        }

        /// <summary>
        /// We get the sums of the dices 
        /// </summary>
        public int DiceValue { get => dice1 + dice2; }

        /// <summary>
        /// We check if dices are equal and get the bool value
        /// </summary>
        public bool IsDiceDouble { get => dice1 == dice2; }

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
        public void Move(int distance)
        {
            //TODO : Find a way to refactor this into a single function ?
            if (distance > 0)
            {
                MoveForward(Math.Abs(distance));
            }
            else
            {
                MoveBackwards(Math.Abs(distance));
            }
        }

        /// <summary>
        /// Moves the player forward, and walk on each space on the way to the destination, then stop on the destination space. Fires any action due to walking or stopping on a space.
        /// </summary>
        /// <param name="distanceToMove">distance to move forward</param>
        private void MoveForward(int distanceToMove)
        {

            for (int step = 0; step < distanceToMove; step++)
            {
                currentPosition++;
                if (currentPosition >= Game.Instance.Board.Count)
                {
                    //If we are after the end of the board, we go back to the beginning.
                    currentPosition -= Game.Instance.Board.Count;
                }
                //We "visit" the space. If the space has an action occuring on walk, it will happen.
                Game.Instance.Board[currentPosition].AcceptWalking((ISpaceVisitor)this);
            }

            //We stop on the space. If the space has an action occuring on stop, it will happen.
            Game.Instance.Board[currentPosition].AcceptStopping((ISpaceVisitor)this);
        }

        /// <summary>
        /// Moves the player forward, and walk on each space on the way to the destination, then stop on the destination space. Fires any action due to walking or stopping on a space.
        /// </summary>
        /// <param name="distanceToMove">distance to move forward</param>
        private void MoveBackwards(int distanceToMove)
        {
            for (int step = 0; step < distanceToMove; step++)
            {
                currentPosition--;
                if (currentPosition < 0)
                {
                    //If we are after the end of the board, we go back to the beginning.
                    currentPosition += Game.Instance.Board.Count;
                }
                //We "visit" the space. If the space has an action occuring on walk, it will happen.
                Game.Instance.Board[currentPosition].AcceptWalking((ISpaceVisitor)this);
            }

            //We stop on the space. If the space has an action occuring on stop, it will happen.
            Game.Instance.Board[currentPosition].AcceptStopping((ISpaceVisitor)this);
        }

        public void Teleport(IVisitableSpace arrival, bool passThroughGoSpace = false)
        {
            int destinationindex = Game.Instance.Board.FindSpaceIndex(arrival);
            if (passThroughGoSpace && destinationindex < currentPosition)
            {//Some luck cards can teleport us while still going through the Go space.
                //In this case we walk on the Go Space
                Game.Instance.Board[0].AcceptWalking((ISpaceVisitor)this);
            }//Whereas the "Go to Jail" event don't
            currentPosition = destinationindex;
            //Then we stop on the destination Space
            Game.Instance.Board[currentPosition].AcceptStopping((ISpaceVisitor)this);
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
