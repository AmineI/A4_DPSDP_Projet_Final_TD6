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
        public Color color;
        public int numberHouses = 0;

        public Land(string id, string name, int buyPrice, int[] rentPrice, Color color) : base(id, name, buyPrice, rentPrice)
        {
            this.color = color;
        }

        public override int RentPrice
        {
            get => rentPrices[numberOfHouses];
        }
    }
}
