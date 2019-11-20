using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public class Player
    {
        //TODO jailed decorator( design pattern ) 
        private int id;
        private string playerName;
        private int position = 0;
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
        /// <summary>
        /// We get the sums of the dices 
        /// </summary>
        public int DiceValue
        {
            get
            {
                return dice1 + dice2;
            }
        }

        /// <summary>
        /// We check if dice are equal and get the bool value
        /// </summary>
        public bool IsDiceDouble
        {
            get
            {
                return dice1 == dice2;
            }
        }

        public void Move(int distance)
        {
            position = position + distance;
            if (position >= 40)
            {
                position -= 40;
                passGo();
            }
        }

        public void TP(Space arrival)
        {
            //TODO get index from Game.Instance.Board


            throw new NotImplementedException();
        }
        public void passGo()
        {
            //TODO argentplus(200);
        }
        /// <summary>
        /// Function for a player turn, launch dice, move(DiceValue)
        /// </summary>
        public void PlayTurn()
        {
            //TODO Decorator for jail 
            //We are not in jail in this fonction 

            //launch dice
            dice1 = Dice.RollDice();
            dice2 = Dice.RollDice();
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
            //Moveplayer on board
            //if passed by Go ( start )  ( case 0 ) {received 200}
            //do event -> pay rent, buy property, pay tax, receive money
            //do player action, build house etc
            //end play 
            //if double = true 
            // players.PlayTurn;



            //
        }

    }


}
