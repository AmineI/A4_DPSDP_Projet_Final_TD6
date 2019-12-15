using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public abstract class Space
    {
        //Auto-property : Can be publicly accessed but can only be set in the constructor. Id and name never changes so it is fine to use them as auto-properties.
        public string Id { get; }
        public string Name { get; }

        protected IBoard board;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Space Id</param>
        /// <param name="name">Space name</param>
        /// <param name="board">Game board where the space has to be added. If null, defaults to the Game Instance's Board</param>
        public Space(string id, string name, IBoard board)
        {
            this.Id = id;
            this.Name = name;
            this.board = board ?? Game.Instance.Board;
        }

    }
}
