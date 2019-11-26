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


        public void Move(int distance)
        {
            currentPosition = currentPosition + distance;
            if (currentPosition >= 40)
            {
                //If we are at the end of the board, we go back to the beginning and pass through the "Go" space
                currentPosition -= 40;
                PassGo();
            }
            else if (currentPosition < 0)
            {
                currentPosition += 40;
            }
            //TODO "visit" each case to fire an eventual event on pass. (The "Go" Space event for example.)
        }

        public void Teleport(Space arrival, bool passThroughGoSpace = false)
        {
            int destinationindex = Game.Instance.Board.FindSpaceIndex(arrival);
            if (passThroughGoSpace && destinationindex < currentPosition)
            {//Some luck cards can teleport us while still going through the Go space.
                PassGo();
            }//Whereas the "Go to Jail" event don't
            currentPosition = destinationindex;
        }
        public void PassGo()
        {
            //TODO Appel de l'event case Départ. ie earn(200);
            Earn(200);          
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
