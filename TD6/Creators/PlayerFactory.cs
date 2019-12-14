using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    static class PlayerFactory
    {
        private static int id = 0;
        public static Player CreatePlayer(string playerName, IGame gameInstance = null)
        {
            id++;
            return new Player(id, playerName, 1500, (char)(id+9631), gameInstance);//9785 is where the common symbols like ☺ start.
        }
    }
}
