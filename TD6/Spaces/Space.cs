using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public abstract class Space
    {
        //Auto-property : Can be publicly accessed but can only be set in the constructor. Id and name never changes so it is fine to use them.
        public string Id { get; }
        public string Name { get; }

        /// <summary>
        /// Event to realize when the user stops on the space.
        /// Action is a delegate type taking a Player parameter and not returning anything.
        /// <example> For exemple
        /// <code>
        /// Action≪Joueur≫ SayHelloToPlayer = delegate (Player player){ Console.WriteLine($"Hi {player}"); };
        /// </code>
        /// </example>
        /// </summary>
        protected Action<Player> eventOnStop;
        public Action<Player> EventOnStop { get => eventOnStop; }


        //TODO : Certaines cases doivent notifier le propriétaire à l'arret (avec un IObserver)
        //TODO : Certaines doivent déplacer le joueur et lui appliquer l'"état" Prison (case "Allez en prison")
        //TODO : Eventuellement certaines cases bonus (chance, etc)

        public Space(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
