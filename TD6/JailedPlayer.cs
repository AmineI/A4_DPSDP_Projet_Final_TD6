﻿    using System.Collections.Generic;

namespace TD6
{
    public class JailedPlayer : IPlayer
    {


        private Player player;
        private int turnInJail = 0;

        public JailedPlayer(Player player)
        {
            this.player = player;
        }

        public int DicesValue => player.DicesValue;

        public bool IsDiceDouble => player.IsDiceDouble;

        public int Id => player.Id;

        public string PlayerName => player.PlayerName;

        public int CurrentPosition => player.CurrentPosition;

        public int Money => player.Money;

        public List<Property> OwnedProperties => player.OwnedProperties;

        public void RollDices()
        {
            player.RollDices();
        }

        public void Earn(int amount)
        {
            player.Earn(amount);
        }

        public void Pay(int amount, IPlayer destinationPlayer)
        {
            player.Pay(amount, destinationPlayer);
        }
        /// <summary>
        /// Removes a player from the jail, allowing him to move freely
        /// </summary>
        public void GetOutOfJail()
        {
            Game.ReplaceIPlayerInstances(this, player);
        }
        /// <summary>
        /// Fonction of a turn with a jailedPlayer
        /// </summary>
        public void PlayTurn()
        {
            RollDices();
            //if we get a double or if we are in jail for the 3rd turn we get out of jail and move 
            if (IsDiceDouble || turnInJail >= 2)
            {
                GetOutOfJail();
                player.Move(DicesValue);
            }
            else
            {
                turnInJail++;
            }
        }



    }
}
