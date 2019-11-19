using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    enum Color { Brown, Cyan, Purple, Orange, Red, Yellow, Green, Blue };

    class Land : Property
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

        //TODO : function to "build a house" on the land
    }
}
