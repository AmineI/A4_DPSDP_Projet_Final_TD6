using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public class Joueur
    {
        //TODO jailed decorator( design pattern ) 
        private int id;
        private string playerName;
        private int position;
        private int money;
        private int dice1;
        private int dice2;
        private int doubleCount;
        public Joueur(int id, string playerName, int money)
        {
            this.id = id;
            this.playerName = playerName;
            
            this.money = money;
            
        }
        /// <summary>
        /// We get the sums of the dice 
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

        

    }


}
