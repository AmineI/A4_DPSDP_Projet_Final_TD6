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

        public Land(string id, string name, int buyPrice, int[] rentPrice, Color color) : base(id, name, buyPrice, rentPrice)
        {
            this.color = color;
        }

        public override int RentPrice
        {
            get => rentPrices[numberOfHouses];
        }

        // TODO : vérifier que le owner est le joueur

        /// <summary>
        /// This funtion check if the player can build a house.
        /// If he can, it build a new house.
        /// If he cannot, it write in the console why the player cannot build a house.
        /// </summary>
        public void BuildHouse()
        {
            List<Land> properties = Game.Instance.Board.FindAllSpaces<Land>(land => land.Color.Equals(color));
            bool buildable = true;
            foreach (Land land in properties)
            {
                if (land.Owner != this.Owner)
                {
                    buildable = false;
                }

                if ((land.NumberOfHouses != numberOfHouses) && (land.NumberOfHouses != numberOfHouses +1))
                {
                    buildable = false;
                }
            }
            if (buildable && numberOfHouses<6)
            {
                numberOfHouses++;
                // TODO : Ajouter le retrait d'argent au joueur
            }
            else if (buildable && numberOfHouses <= 6)
            {
                Console.WriteLine("You can't build more than an hotel on this land.");
            }
            else
            {
                Console.WriteLine("You can't build a house if you are not the owner of all the properties in this color or if" +
                    "you haven't got the same number of houses on every land.");
            }
        }

    }
}
