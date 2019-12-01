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
        public int housePrice;

        /// <param name="rentPrice">rent price list according to the number of houses built on the land. Up to 6 houses.</param>
        public Land(string id, string name, Color color, int buyPrice, int[] rentPrices, int housePrice) : base(id, name, buyPrice, rentPrices)
        {
            this.housePrice = housePrice;
            this.color = color;
        }

        public override int RentPrice
        {
            get => GetRentPrice();
        }

        ///A land can be sold only if there is no house on it
        public override bool CanBeSold => numberOfHouses != 0;
        /// <summary>
        /// This function gives the rent of the land based on the number of houses and land owned by the land owner.
        /// </summary>
        /// <returns> An integer representing the price of rent</returns>
        public int GetRentPrice()
        {
            int rentPrice = rentPrices[numberOfHouses];
            List<Land> sameColorLands = Game.Instance.Board.FindAllSpaces<Land>(land => land.Color.Equals(color));
            bool sameOwner = true;
            foreach (Land land in sameColorLands)
            {
                if (land.Owner != this.Owner)
                {
                    sameOwner = false;
                }
            }
            if (sameOwner && numberOfHouses == 0)
            {
                rentPrice = rentPrice * 2;
            }
            return rentPrice;
        }

        // TODO : vérifier que le owner est le joueur

        /// <summary>
        /// This function checks if the player can build a house on this land.
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
                this.Owner.Pay(housePrice);
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


    }
}
