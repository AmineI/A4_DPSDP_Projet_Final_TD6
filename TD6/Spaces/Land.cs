using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public enum Color { Brown, Cyan, Purple, Orange, Red, Yellow, Green, Blue };

    public class Land : Property
    {
        private Color color;
        public Color Color { get => color; }
        private int numberOfHouses = 0;
        public int NumberOfHouses { get => numberOfHouses; }
        public int priceHouse;

        public Land(string id, string name, int buyPrice, int[] rentPrice, Color color, int price) : base(id, name, buyPrice, rentPrice)
        {
            this.priceHouse = price;
            this.color = color;
        }

        public override int RentPrice
        {
            get => rentPrices[numberOfHouses];
        }

        // TODO : vérifier que le owner est le joueur

        /// <summary>
        /// This funtion check if the player can build a house.
        /// If he can, it build a new house and he pays for the construction of the house.
        /// If he cannot, it write in the console why the player cannot build a house.
        /// </summary>
        public void BuildHouse()
        {
            List<Land> sameColorLands = Game.Instance.Board.FindAllSpaces<Land>(land => land.Color.Equals(color));
            bool buildable = true;
            foreach (Land land in sameColorLands)
            {
                if (land.Owner != this.Owner)
                {
                    buildable = false;
                }

                if (land.NumberOfHouses < this.numberOfHouses) 
                {
                    buildable = false;
                }
            }
            if (buildable && this.numberOfHouses<6)
            {
                numberOfHouses++;
                this.Owner.Pay(priceHouse);
            }
            else if (buildable && this.numberOfHouses <= 6)
            {
                // TODO : trouver un moyen d'éviter le WriteLine 
                Console.WriteLine("You can't build more than an hotel on this land.");
            }
            else
            {
                Console.WriteLine("You can't build a house if you are not the owner of all the properties in this color or if" +
                    "you haven't got the same number of houses on every land.");
            }
        }

        /// <summary>
        /// Checks if the number of house on this land is equal to 0.
        /// </summary>
        /// <returns> A boolean representing if the land can be sold (so if it don't have any house)</returns>
        public override bool CanBeSold()
        {
            bool res = false;
            if (numberOfHouses == 0)
            {
                res = true;
            }
            return res;
        }

    }
}
